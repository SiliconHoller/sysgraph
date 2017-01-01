using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// Model for encapsulating the relationships between nodes, such as a server within a domain or a schema within a database
    /// </summary>
    public class Membership
    {
        [Display(Name = "Membership Type Id")]
        public int memTypeId { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType memType { get; set; }
 
        #region Relationship Ids
        [Display(Name="Group Node Id")]
        public int containingNodeId { get; set; }
        [Display(Name="Member Node Id")]
        public int residentNodeId { get; set; }
        [Display(Name = "Process Id")]
        public int containingProcessId { get; set; }
        [Display(Name = "Edge Id")]
        public int residentEdgeId { get; set; }

        #endregion

        #region Reference values

        [Display(Name = "Group Node")]
        public Node containingNode { get; set; }
        [Display(Name="Resident Node")]
        public Node residentNode { get; set; }
        [Display(Name = "Group Process")]
        public Process containingProcess { get; set; }
        [Display(Name = "Edge")]
        public Edge residentEdge { get; set; }

        #endregion
    }
}
