using AirbnbAPI.Models;
using Data.Model;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> UserManager;
        private SignInManager<User> SignInManager;
        private IEmailSender EmailSender;
        private IHttpContextAccessor HttpContextAccessor;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            EmailSender = emailSender;
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/User/Register
        public async Task<IActionResult> PostApplicationUser(RegisterUser model)
        {
            var applicationUser = new User()
            {
                Fname = model.Fname,
                Lname = model.Lname,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                City = model.City
                //BirthDate = model.BirthDate,
                //Image = model.Image,
                //Gender = model.Gender,
                //Street = model.Street,
            };

            try
            {
                var result = await UserManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/User/Login
        public async Task<IActionResult> Login(LoginUser model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("sub",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await UserManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return NotFound();
            var token = await UserManager.GeneratePasswordResetTokenAsync(user);
            var mail = new Message(new string[] { user.Email }, "Reset Password Token", "Password reset Token is: " + token);
            await EmailSender.SendEmailAsync(mail);
            return Ok();
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var user = await UserManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                return NotFound();
            var resetPass = await UserManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPass.Succeeded)
                return BadRequest();
            return Ok();
        }
        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            await UserManager.ChangePasswordAsync(user, changePasswordModel.CurrPassword, changePasswordModel.NewPassword);
            return Ok();
        }
        [HttpGet]
        [Route("UserDetails")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails()
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            return Ok(user);
        }
        [HttpPut]
        [Route("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(User model)
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Fname = model.Fname;
            user.Lname = model.Lname;
            user.Image = model.Image;
            user.PhoneNumber = model.PhoneNumber;
            user.Street = model.Street;
            user.Zipcode = model.Zipcode;
            user.Gender = model.Gender;
            user.Country = model.Country;
            user.City = model.City;
            user.BirthDate = model.BirthDate;
            await UserManager.UpdateAsync(user);
            return Ok("User Updated");
        }
    }
}
