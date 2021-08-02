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
        public async Task<ActionResult> getall()
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
        public async Task<ActionResult> DeletePropertyReview(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddPropertyReview(PropertyReview PropertyReview)
        {

            var x = await _context.InsertAsync(PropertyReview);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePropertyReview(PropertyReview PropertyReview)
        {
            await _context.UpdateAsync(PropertyReview);
            return Ok("PropertyReview Updated");
        }

    }
}
