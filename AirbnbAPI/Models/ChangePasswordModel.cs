using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbAPI.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string CurrPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
