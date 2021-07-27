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
        public IActionResult getall()
        {
            return Ok(_context.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Wishlist> WishlistById(int id)
        {
            Wishlist p = _context.GetById(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWishlist(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddWishlist(Wishlist Wishlist)
        {

            _context.Insert(Wishlist);
            return Ok("Wishlist Adeed");
        }

        [HttpPut]
        public IActionResult UpdateWishlist(Wishlist Wishlist)
        {
            _context.Update(Wishlist);
            return Ok("Wishlist Updated");
        }

    }
}
