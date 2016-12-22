using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    public class NodeAttribute
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Node Id")]
        public int nodeId { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Type")]
        public AttributeType type { get; set; }
    }
}
