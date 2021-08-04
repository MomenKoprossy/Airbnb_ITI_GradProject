using AirbnbAPI.Models;
using Data.Model;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
        private readonly IWebHostEnvironment _host;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment host) 
        {
            UserManager = userManager;
            SignInManager = signInManager;
            EmailSender = emailSender;
            HttpContextAccessor = httpContextAccessor;
            _host = host;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/User/Register
        public async Task<ActionResult> PostApplicationUser(RegisterUser model)
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
        public async Task<ActionResult> Login(LoginUser model)
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
                var userData = new { user.Fname, user.Image };
                return Ok(new { token , userData });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
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
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
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
        public async Task<ActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            var result = await UserManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            return Ok(result);
        }
        [HttpGet]
        [Route("UserDetails")]
        [Authorize]
        public async Task<ActionResult> GetUserDetails()
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            return Ok(user);
        }
        [HttpPut]
        [Route("UpdateUser")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UpdateUserModel model)
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            if (model.Fname != "")
                user.Fname = model.Fname;
            if (model.Lname != "")
                user.Lname = model.Lname;
            if (model.PhoneNumber != "")
                user.PhoneNumber = model.PhoneNumber;
            if (model.Street != "")
                user.Street = model.Street;
            if (model.ZipCode != 0)
                user.Zipcode = model.ZipCode;
            if (model.Country != "")
                user.Country = model.Country;
            if (model.City != "")
                user.City = model.City;
            if (!string.IsNullOrEmpty(model.BirthDate.ToString()))
                user.BirthDate = model.BirthDate;
            if (model.Gender != null)
                user.Gender = model.Gender;
            var result = await UserManager.UpdateAsync(user);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProfilePicture")]
        [Authorize]
        public async Task<ActionResult> UpdateProfilePicture()
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);

            //Upload Image
            //var postedFile = HttpContext.Request.Form.Files["image"];
            var File = Request.Form.Files.FirstOrDefault();
            var FileName = user.Id + File.FileName;
            string uploads = Path.Combine(_host.WebRootPath, @"images\profile");
            string fullpath = Path.Combine(uploads, FileName);
            File.CopyTo(new FileStream(fullpath, FileMode.Create));
            
            user.Image = FileName;
            var result = await UserManager.UpdateAsync(user);
            return Ok(new { result, image = user.Image });
        }

    }
}
