using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// <para>A Connector is a model for a simple, direct relationship between two Nodes (components, systems, etc).</para>
    /// <para>Connectors can be as simple as Foreign Key relationships between tables or direct operations (CRUD) from one system to another.  They do 
    /// not have subcomponents or sub-connectors.  If that is required, use the Process model.</para>
    /// </summary>
    public class Edge
    {
        #region Properties
        
        [Display(Name="Id")]
        public int id { get; set; }
        [Display(Name="Type")]
        public EdgeType type { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType memType { get; set; }
        [Display(Name="Name")]
        public string name { get; set; }
        [Display(Name="Description")]
        public string description { get; set; }
        [Display(Name="From Component Id")]
        public int fromNodeId { get; set; }
        [Display(Name="To Component Id")]
        public int toNodeId { get; set; }
        [Display(Name="From Component")]
        public Node fromNode { get; set; }
        [Display(Name="To Component")]
        public Node toNode { get; set; }

        #endregion

        #region Associations

        [Display(Name = "Processes")]
        public IEnumerable<Process> processes { get; set; }
        [Display(Name = "Attributes")]
        public IEnumerable<EdgeAttribute> attributes { get; set; }
        [Display(Name = "Docs")]
        public IEnumerable<Documentation> docs { get; set; }

        #endregion

        #region Calculated values

        [Display(Name="Total Value")]
        public decimal? val
        {
            get
            {
                decimal? retval = null;
                if (attributes != null)
                {
                    retval = attributes.Sum(a => a.edgeVal);
                }
                return retval;
            }
        }

        #endregion
    }
}
