using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Property> Properties { get; set; }
    }
}
