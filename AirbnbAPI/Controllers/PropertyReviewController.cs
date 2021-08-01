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
    public class PropertyReviewController : ControllerBase
    {
        private readonly IRepository<PropertyReview> _context;
        public PropertyReviewController(IRepository<PropertyReview> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyReview>> PropertyReviewById(int id)
        {
            PropertyReview p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePropertyReview(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddPropertyReview(PropertyReview PropertyReview)
        {

            _context.Insert(PropertyReview);
            return Ok("PropertyReview Added");
        }

        [HttpPut]
        public IActionResult UpdatePropertyReview(PropertyReview PropertyReview)
        {
            _context.Update(PropertyReview);
            return Ok("PropertyReview Updated");
        }

    }
}
