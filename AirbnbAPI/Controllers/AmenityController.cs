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
        public IActionResult getall()
        {
            return Ok(_context.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Amenity> AmenityById(int id)
        {
            Amenity p = _context.GetById(id,"");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAmenity(int id)
        {
            _context.Delete(id,"");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddAmenity(Amenity Amenity)
        {

            _context.Insert(Amenity);
            return Ok("Amenity Adeed");
        }

        [HttpPut]
        public IActionResult UpdateAmenity(Amenity Amenity)
        {
            _context.Update(Amenity);
            return Ok("Amenity Updated");
        }

    }
}
