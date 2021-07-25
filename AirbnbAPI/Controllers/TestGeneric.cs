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
    public class TestGeneric : ControllerBase
    {
        private readonly IRepository<User> _context;

        public TestGeneric(IRepository<User> context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getall()
        {
            return Ok(_context.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<User> UserById(int id)
        {
            User u = _context.GetById(id);
            return u;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _context.Delete(id);
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddUser(User user)
        {

            _context.Insert(user);
            return Ok("User Adeed");
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            _context.Update(user);
            return Ok("User Updated");
        }






    }
}
