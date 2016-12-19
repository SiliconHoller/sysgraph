using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;
using SystemMap.Models;

namespace SystemMap.Entities.service
{
    /// <summary>
    /// Provides higher-level relationship lookup services for the System information graph
    /// in Persistent storage
    /// </summary>
    public class GraphService
    {
        /// <summary>
        /// Returns a full graph adjacency list of all edges
        /// </summary>
        /// <returns>Adjacency list in the form of a Dictionary</returns>
        public Dictionary<int, IEnumerable<int>> GetFullEdgeList()
        {
            Dictionary<int, IEnumerable<int>> adjList = new Dictionary<int, IEnumerable<int>>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                List<int> nlist = db.nodes.Select(n => n.nodeid).ToList<int>();
                foreach (int nid in nlist)
                {
                    List<int> elist = db.edges
                                        .Where(e => e.from_node == nid)
                                        .Select(e => e.to_node)
                                        .ToList<int>();
                    adjList.Add(nid, elist);
                }
            }
            return adjList;
        }

        /// <summary>
        /// Returns a full graph adjacency list of all processes
        /// </summary>
        /// <returns>Adjacency list in the form of a Dictionary</returns>
        public Dictionary<int, IEnumerable<int>> GetFullProcessList()
        {
            Dictionary<int, IEnumerable<int>> adjList = new Dictionary<int, IEnumerable<int>>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                List<int> nlist = db.nodes.Select(n => n.nodeid).ToList<int>();
                foreach (int nid in nlist)
                {
                    List<int> elist = db.processes
                                        .Where(p => p.from_node == nid)
                                        .Select(p => p.to_node)
                                        .ToList<int>();
                    adjList.Add(nid, elist);
                }
            }
            return adjList;
        }

        /// <summary>
        /// Returns an edge adjacency list, starting wtih the given node type
        /// </summary>
        /// <param name="ntype">Node type of interest</param>
        /// <returns>Adjacency list in the form of a Dictionary</returns>
        public Dictionary<int, IEnumerable<int>> GetTypeEdgeList(int ntype)
        {
            Dictionary<int, IEnumerable<int>> adjList = new Dictionary<int, IEnumerable<int>>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                List<int> nlist = db.nodes
                                    .Where(n=>n.typeid == ntype)
                                    .Select(n => n.nodeid).ToList<int>();
                foreach (int nid in nlist)
                {
                    List<int> elist = db.edges
                                        .Where(e => e.from_node == nid)
                                        .Select(e => e.to_node)
                                        .ToList<int>();
                    adjList.Add(nid, elist);
                }
            }
            return adjList;
        }

        /// <summary>
        /// Returns a process adjacency list, starting with the given node type
        /// </summary>
        /// <param name="ntype">Node type of interest</param>
        /// <returns>Adjacency list in the form of a Dictionary</returns>
        public Dictionary<int, IEnumerable<int>> GetTypeProcessList(int ntype)
        {
            Dictionary<int, IEnumerable<int>> adjList = new Dictionary<int, IEnumerable<int>>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                List<int> nlist = db.nodes
                                    .Where(n => n.typeid == ntype)
                                    .Select(n => n.nodeid).ToList<int>();
                foreach (int nid in nlist)
                {
                    List<int> elist = db.processes
                                        .Where(p => p.from_node == nid)
                                        .Select(p => p.to_node)
                                        .ToList<int>();
                    adjList.Add(nid, elist);
                }
            }
            return adjList;
        }


    }
}
