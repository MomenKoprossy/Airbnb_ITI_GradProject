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
    public class AmenityController : ControllerBase
    {
        private readonly IRepository<Amenity> _context;
        public AmenityController(IRepository<Amenity> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> AmenityById(int id)
        {
            Amenity p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAmenity(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddAmenity(Amenity Amenity)
        {
            int x = await _context.InsertAsync(Amenity);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAmenity(Amenity Amenity)
        {
            await _context.UpdateAsync(Amenity);
            return Ok("Amenity Updated");
        }

    }
}
