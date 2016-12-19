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

        [Display(Name="Sibling Components")]
        public IEnumerable<Node> siblings { get; set; }
        [Display(Name="Component of")]
        public IEnumerable<Node> containers { get; set; }
        [Display(Name = "Inhabitants")]
        public IEnumerable<Node> residents { get; set; }
        [Display(Name="Dependencies")]
        public IEnumerable<Connector> dependencies { get; set; }
        [Display(Name = "Dependents")]
        public IEnumerable<Connector> dependents { get; set; }
        [Display(Name="Processes Involved")]
        public IEnumerable<Process> processes { get; set; }
    }
}
