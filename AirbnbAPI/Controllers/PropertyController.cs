using App.Repository;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IRepository<Property> _context;
        private UserManager<User> UserManager;
        public PropertyController(UserManager<User> userManager, IRepository<Property> context)
        {
            _context = context;
            UserManager = userManager;
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
            return Ok(p);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost("AddProperty")]
        [Authorize]

        public async Task<ActionResult> AddProperty(Property property)
        {
            var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await UserManager.FindByIdAsync(uid);
            property.PropertyHostID = user.Id;

            var x = await _context.InsertAsync(property);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProperty(Property property)
        {
            await _context.UpdateAsync(property);
            return Ok("property Updated");
        }
        [HttpGet("country/{country}")]
        public async Task<ActionResult> GetNearbyPlaces(string country)
        {
            var x = await _context.GetNearbyPlacesAsync(country);
            return Ok(x);
        }

    }
}
