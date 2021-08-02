using Data.Model;
using DataEF;
using Itenso.TimePeriod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbAPI.ActionFilters
{
    public class EnsureReservationAvailablity : ActionFilterAttribute
    {
        private readonly AirbnbModel _context;
        public EnsureReservationAvailablity(AirbnbModel context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var reservation = context.ActionArguments["Reservation"] as Reservation;
            var PropertyReservations = _context.Reservations.Where(x => x.PropertyID == reservation.PropertyID);
            var range = new TimeRange(reservation.ReservationSartDate, reservation.ReservationEndDate);
            foreach (var res in PropertyReservations)
            {
                var resRange = new TimeRange(res.ReservationSartDate, res.ReservationEndDate);
                if (resRange.IntersectsWith(range))
                {
                    context.ModelState.AddModelError("Reservation Time Overlap", "Property is already reserved in the provided time range");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                    break;
                }
            }
        }
    }
}
