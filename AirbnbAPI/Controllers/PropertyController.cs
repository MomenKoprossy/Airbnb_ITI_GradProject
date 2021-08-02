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
        public async Task<ActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> PropertyById(int id)
        {
            Property p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddProperty(Property property)
        {

            var x = await _context.InsertAsync(property);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProperty(Property property)
        {
            await _context.UpdateAsync(property);
            return Ok("property Updated");
        }
        public async Task<ActionResult> GetNearbyPlaces(string country)
        {
            await _context.GetNearbyPlacesAsync(country);
            return Ok();
        }

    }
}
