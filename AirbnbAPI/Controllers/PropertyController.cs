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
    public class PropertyController : ControllerBase
    {
        private readonly IRepository<Property> _context;
        public PropertyController(IRepository<Property> context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(_context.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Property> PropertyById(int id)
        {
            Property p = _context.GetById(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddProperty(Property property)
        {

            _context.Insert(property);
            return Ok("property Added");
        }

        [HttpPut]
        public IActionResult UpdateProperty(Property property)
        {
            _context.Update(property);
            return Ok("property Updated");
        }

    }
}
