using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Wishlist
    {
        [Key]
        public int WishlistID { get; set; }
        [Required]
        public string WishlistTitle { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ICollection<Property> Properties { get; set; }

    }
}
