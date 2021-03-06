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
    public class PropertyImage
    {
        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
    }
}
