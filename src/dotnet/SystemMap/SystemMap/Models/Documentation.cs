using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{
    /// <summary>
    /// Generic container for documentation, used for Nodes, Edges, and processes
    /// </summary>
    public class Documentation
    {
        public int documentationId { get; set; }
        public int componentId { get; set; }
        public int docTypeId { get; set; }
        public DocType documentType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }

    }
}
