using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// Simple container for Node type values
    /// </summary>
    public class NodeType
    {
        [Display(Name="Type Id")]
        public int typeId { get; set; }
        [Display(Name = "Type Name")]
        public string name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Icon Url")]
        public string iconUrl { get; set; }
    }
}
