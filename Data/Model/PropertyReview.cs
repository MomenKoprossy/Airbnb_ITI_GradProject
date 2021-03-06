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
    public class PropertyReview
    {

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Review { get; set; }
        [Required]
        public string Rating { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ReviewDate { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
        public User User { get; set; }




    }
}
