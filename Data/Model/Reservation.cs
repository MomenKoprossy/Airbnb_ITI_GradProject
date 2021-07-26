using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Reservation
    {
        [Key]
        public int? ReservationID { get; set; }
        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ReservationSartDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ReservationEndDate { get; set; }
        public int TotalPrice { get; set; }
        public User User { get; set; }
        public Property Property { get; set; }
    }
}
