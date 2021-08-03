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
        [Column(name: "PropertyId")]
        public int PropertyID { get; set; }
        [Column(name: "Name")]
        [Required]
        public string PropertyName { get; set; }
        [Column(name: "PricePerNight")]
        [Required]
        public int PropertyPricePerNight { get; set; }
        [Column(name: "Longitude")]
        [Required]
        public double PropertyLongitude { get; set; }
        [Column(name: "Latitude")]
        [Required]
        public double Propertylatitude { get; set; }
        [Column(name: "Description")]
        [Required]
        public string PropertyDescription { get; set; }
        [Column(name: "MaxOccupation")]
        [Required]
        public int PropertyMaxOccupation { get; set; }
        [Column(name: "TotalBeds")]
        [Required]
        public int PropertyTotalBeds { get; set; }
        [Column(name: "TotalRooms")]
        [Required]
        public int PropertyTotalRooms { get; set; }
        [Column(name: "TotalBathrooms")]
        [Required]
        public int PropertyTotalBathrooms { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Column(name: "Type")]
        [Required]
        public string PropertyType { get; set; }
        [Column(name: "HostId")]
        [ForeignKey("User")]
        public string PropertyHostID { get; set; }
        public User User { get; set; }
        public ICollection<Amenity> Amenities { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }

    }
}
