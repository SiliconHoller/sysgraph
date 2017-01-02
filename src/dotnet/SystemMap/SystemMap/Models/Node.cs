using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// A Node is a model for a definable, contained component or subcomponent.
    /// </summary>
    public class Node
    {
        [Display(Name="Id")]
        public int id { get; set; }
        [Display(Name="Name")]
        public string name { get; set; }
        [Display(Name="Description")]
        public string description { get; set; }
        [Display(Name="Type")]
        public NodeType type { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType memType { get; set; }

        [Display(Name = "NameSpace")]
        public NameSpace lineage { get; set; }

        [Display(Name="Dependencies")]
        public IEnumerable<Edge> dependencies { get; set; }
        [Display(Name = "Dependents")]
        public IEnumerable<Edge> dependents { get; set; }
        [Display(Name="Processes Involved")]
        public IEnumerable<Process> processes { get; set; }
        [Display(Name = "Attributes")]
        public IEnumerable<NodeAttribute> attributes { get; set; }
        [Display(Name = "Docs")]
        public IEnumerable<Documentation> docs { get; set; }

       #region Calculated values

        [Display(Name = "Total Value")]
        public decimal? val
        {
            get
            {
                decimal? retval = null;
                if (attributes != null)
                {
                    retval = attributes.Sum(a => a.nodeVal);
                }
                return retval;
            }
        }

        #endregion
    }
}
