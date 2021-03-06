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
    public class HostLanguage
    {
        [ForeignKey("User")]
        public string HostID { get; set; }
        public string Language { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
