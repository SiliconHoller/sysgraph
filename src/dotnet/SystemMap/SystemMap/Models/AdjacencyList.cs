using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models
{

    public class AdjacencyList
    {
        [Display(Name="Entires")]
        public IEnumerable<AdjacencyListEntry> entries { get; set; }


        public AdjacencyList(Dictionary<int, IEnumerable<int>> adjDictionary)
        {
            List<AdjacencyListEntry> alist = new List<AdjacencyListEntry>();
            foreach (int keyval in adjDictionary.Keys)
            {
                alist.Add(new AdjacencyListEntry { nodeId = keyval, connections = adjDictionary[keyval] });
            }
            entries = alist;
        }
    }

    public class AdjacencyListEntry
    {
        [Display(Name = "Node Id")]
        public int nodeId { get; set; }
        [Display(Name = "Connections")]
        public IEnumerable<int> connections { get; set; }
    }
}
