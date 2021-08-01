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
        public async Task<IActionResult> getall()
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
        public IActionResult DeleteAmenity(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");

        }
        [HttpPost]

        public IActionResult AddAmenity(Amenity Amenity)
        {

            _context.Insert(Amenity);
            return Ok("Amenity Added");
        }

        [HttpPut]
        public IActionResult UpdateAmenity(Amenity Amenity)
        {
            _context.Update(Amenity);
            return Ok("Amenity Updated");
        }

    }
}
