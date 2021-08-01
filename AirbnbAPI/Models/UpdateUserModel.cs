using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbAPI.Models
{
    public class UpdateUserModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Zipcode { get; set; }
        public string PhoneNumber { get; set; }

    }
}
