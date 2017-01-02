using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    public class NameSpace
    {
        [Display(Name="Node Id")]
        public int nodeId { get; set; }
        [Display(Name="Node")]
        public Node node { get; set; }
        [Display(Name="Membership line")]
        public IEnumerable<Membership> containers { get; set; }
        [Display(Name="Residents")]
        public IEnumerable<Membership> residents { get; set; }
        [Display(Name="Siblings")]
        public IEnumerable<Membership> siblings { get; set; }


        [Display(Name = "Namespace")]
        public string lineageValue
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            if (containers == null) return "";
            StringBuilder sb = new StringBuilder();
            foreach (Membership mem in containers)
            {
                if (mem.containingNode != null)
                {
                    sb.Append(mem.containingNode.name);
                    sb.Append("::");
                }
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is NameSpace)) return false;
            NameSpace ons = (NameSpace)obj;
            //return if the underlying nodes are the same
            if (nodeId != 0 && ons.nodeId != 0) return nodeId == ons.nodeId;
            bool retval = false;
            if (containers != null && ons.containers != null)
            {
                if (containers.Count() != ons.containers.Count()) return false;
                retval = true;
                for (int i = 0; i < containers.Count(); i++)
                {
                    retval = retval && containers.ElementAt(i).containingNode.name.Equals(ons.containers.ElementAt(i).containingNode.name, StringComparison.CurrentCultureIgnoreCase);
                }
            }
            return retval;
        }
    }
}
