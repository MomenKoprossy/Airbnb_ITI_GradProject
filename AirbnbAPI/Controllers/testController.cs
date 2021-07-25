using App.Repository;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IUserRepository _context;

        public testController(IUserRepository context)
        {
            _context = context;
        }
        [HttpGet]
       public IActionResult getall()
        {
            return Ok(_context.GetAllUsers());
        }
        [HttpGet("{id}")]
        public ActionResult<User> UserById(int id)
        {
            User u = _context.GetUser(id);
            return u;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _context.DeleteUser(id);
            return Ok("deleted");
        }

        [HttpPost]

        public IActionResult AddUser(User user)
        {
           
            _context.SaveUser(user);
            return Ok("User Adeed");
        }
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            _context.UpdateUser(user);
            return Ok("User Updated");
        }

       


    }
}
