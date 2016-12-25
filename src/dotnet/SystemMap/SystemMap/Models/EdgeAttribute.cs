using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    public class EdgeAttribute
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Edge Id")]
        public int edgeId { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Type")]
        public AttributeType type { get; set; }
        [Display(Name = "Value")]
        public decimal edgeVal { get; set; }
    }
}
