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
    public class PropertyImageController : ControllerBase
    {
        private readonly IRepository<PropertyImage> _context;
        public PropertyImageController(IRepository<PropertyImage> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            return  Ok(await  _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyImage>> PropertyImageById(int id)
        {
            PropertyImage p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePropertyImage(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddPropertyImage(PropertyImage PropertyImage)
        {

            _context.Insert(PropertyImage);
            return Ok("PropertyImage Added");
        }

        [HttpPut]
        public IActionResult UpdatePropertyImage(PropertyImage PropertyImage)
        {
            _context.Update(PropertyImage);
            return Ok("PropertyImage Updated");
        }

    }
}
