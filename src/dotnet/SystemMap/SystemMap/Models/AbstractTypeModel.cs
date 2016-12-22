using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// Master class for all the type models.  Provides common fields and common methods.
    /// </summary>
    public abstract class AbstractTypeModel
    {
        [Display(Name = "Type Id")]
        public int typeId { get; set; }
        [Display(Name = "Type Name")]
        public string name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Icon Url")]
        public string iconUrl { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
