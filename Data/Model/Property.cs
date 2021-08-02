using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PricePerNight { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxOccupation { get; set; }
        [Required]
        public int TotalBeds { get; set; }
        [Required]
        public int TotalRooms { get; set; }
        [Required]
        public int TotalBathrooms { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [ForeignKey("User")]
        public string HostId { get; set; }
        public User User { get; set; }
        public ICollection<Amenity> Amenities { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }

    }
}
