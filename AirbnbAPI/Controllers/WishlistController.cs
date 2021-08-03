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
    public class WishlistController : ControllerBase
    {
        private readonly IRepository<Wishlist> _context;
        public WishlistController(IRepository<Wishlist> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> WishlistById(int id)
        {
            Wishlist p = await _context.GetByIdAsync(id, "");
            return Ok(p);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWishlist(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddWishlist(Wishlist Wishlist)
        {
            var x = await _context.InsertAsync(Wishlist);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateWishlist(Wishlist Wishlist)
        {
            await _context.UpdateAsync(Wishlist);
            return Ok("Wishlist Updated");
        }

    }
}
