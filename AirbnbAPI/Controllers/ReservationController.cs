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
        public IActionResult getall()
        {
            return Ok(_context.GetAll());
        }
        [HttpGet("{id}")]
        //public ActionResult<Reservation> ReservationById()
        //{
        //    var uid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    return Ok(_context.GetUserReservations(uid));
        //}
        [HttpGet]
        public ActionResult<Reservation> ReservationById(int id)
        {
            Reservation p = _context.GetById(id, "");
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            _context.Delete(id, "");
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddReservation(Reservation Reservation)
        {

            _context.Insert(Reservation);
            return Ok("Reservation Added");
        }

        [HttpPut]
        public IActionResult UpdateReservation(Reservation Reservation)
        {
            _context.Update(Reservation);
            return Ok("Reservation Updated");
        }

    }
}
