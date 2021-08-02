using App.Repository;
using Data.Model;
using Microsoft.AspNetCore.Http;
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
    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> _context;
        public ReservationController(IRepository<Reservation> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> ReservationById(int id)
        {
            Reservation p = await _context.GetByIdAsync(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddReservation(Reservation Reservation)
        {

            var x = await _context.InsertAsync(Reservation);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReservation(Reservation Reservation)
        {
            await _context.UpdateAsync(Reservation);
            return Ok("Reservation Updated");
        }

    }
}
