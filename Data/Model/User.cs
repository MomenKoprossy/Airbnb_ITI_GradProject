using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data.Model
{
    public class User : IdentityUser
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Column(name: "DOB", TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Street { get; set; }
        public int? Zipcode { get; set; }
    }
}
