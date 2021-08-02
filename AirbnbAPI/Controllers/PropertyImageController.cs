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
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyImage>> PropertyImageById(int id)
        {
            PropertyImage p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePropertyImage(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddPropertyImage(PropertyImage PropertyImage)
        {
            var x = await _context.InsertAsync(PropertyImage);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePropertyImage(PropertyImage PropertyImage)
        {
            await _context.UpdateAsync(PropertyImage);
            return Ok("PropertyImage Updated");
        }

    }
}
