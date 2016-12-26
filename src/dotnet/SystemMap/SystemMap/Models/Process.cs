using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// Model for processes, which are overarching Connectors that are made up of sub-nodes and connection paths
    /// </summary>
    public class Process
    {
        [Display(Name="Process Id")]
        public int id { get; set; }
        [Display(Name="Process Type")]
        public EdgeType type { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType memType { get; set; }
        [Display(Name="Process Name")]
        public string name { get; set; }
        [Display(Name="Description")]
        public string description { get; set; }
        [Display(Name="Source Node Id")]
        public int fromNodeId { get; set; }
        [Display(Name="Target Node Id")]
        public int toNodeId { get; set; }
        [Display(Name="Source Node")]
        public Node fromNode { get; set; }
        [Display(Name="Target Node")]
        public Node toNode { get; set; }
        [Display(Name="Operators")]
        public IEnumerable<Node> actors { get; set; }
        [Display(Name="Operations")]
        public IEnumerable<Edge> actions { get; set; }

        #region Calculated values

        [Display(Name = "Node Total")]
        public decimal? nodeSum
        {
            get
            {
                decimal? retval = null;
                if (actors != null)
                {
                    retval = actors.Sum(a => a.val);
                }
                return retval;
            }
        }

        [Display(Name="Edge Total")]
        public decimal? edgeSum
        {
            get
            {
                decimal? retval = null;
                if (actions != null)
                {
                    retval = actions.Sum(e => e.val);
                }
                return retval;
            }
        }

        #endregion

    }
}
