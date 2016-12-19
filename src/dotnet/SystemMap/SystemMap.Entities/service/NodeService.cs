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
    /// Provides basic CRUD operations for Node values, particularly for discovery and definition operations
    /// </summary>
    public class NodeService
    {
        public Node GetNode(int nodeid)
        {
            Node retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                retval = db.nodes.Where(n => n.nodeid == nodeid)
                            .Select(n=> new Node {
                                id = n.nodeid,
                                name = n.name,
                                description = n.descr,
                                type = new NodeType
                                {
                                    typeId = n.nodetype.typeid,
                                    name = n.nodetype.name,
                                    iconUrl = n.nodetype.iconurl,
                                    description = n.nodetype.descr
                                }
                            })
                            .SingleOrDefault();
            }
            return retval;
        }

        public IEnumerable<Node> GetNodesOfType(int typeid)
        {
            List<Node> nlist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nlist = db.nodetypes
                            .Where(t => t.typeid == typeid)
                            .Join(db.nodes, a => a.typeid, b => b.typeid, (a, b) => b)
                            .Select(n => new Node
                            {
                                id = n.nodeid,
                                name = n.name,
                                description = n.descr
                            })
                            .ToList<Node>();
            }

            return nlist;
        }

        public IEnumerable<Node> GetContainers(int nodeid)
        {
            List<Node> clist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                clist = db.node_membership
                            .Where(nm => nm.membernode_id == nodeid)
                            .Join(db.nodes, a => a.groupnode_id, b => b.nodeid, (a, b) => new { memtype = a.memtypeid, container = b })
                            .Select(n => new Node
                            {

                            })
                            .ToList<Node>();
            }
            return clist;
        }

        /// <summary>
        /// Returns a list of Nodes that are affected by or depend on the given node
        /// </summary>
        /// <param name="nodeid">Core node of interest</param>
        /// <returns>Collection of nodes that depend on the given node; otherwise, an empty Collection</returns>
        public IEnumerable<Node> GetChildren(int nodeid)
        {
            List<Node> nlist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nlist = db.edges
                            .Where(e => e.from_node == nodeid)
                            .Join(db.nodes, a => a.to_node, b => b.nodeid, (a, b) => b)
                            .Select(c => new Node
                            {
                                id = c.nodeid,
                                name = c.name,
                                description = c.descr,
                                type = new NodeType
                                {
                                    typeId = c.nodetype.typeid,
                                    name = c.nodetype.name,
                                    iconUrl = c.nodetype.iconurl,
                                    description = c.nodetype.descr
                                }
                            })
                            .ToList<Node>();
            }
            return nlist;
        }

        /// <summary>
        /// Returns a Collection of nodes on which the given node depends
        /// </summary>
        /// <param name="nodeid">Node of interest</param>
        /// <returns>Collection of nodes that provide data or reference for the node given; otherwise, an empty collection</returns>
        public IEnumerable<Node> GetParents(int nodeid)
        {
            List<Node> nlist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nlist = db.edges
                            .Where(e => e.to_node == nodeid)
                            .Join(db.nodes, a => a.from_node, b => b.nodeid, (a, b) => b)
                            .Select(p => new Node
                            {
                                id = p.nodeid,
                                name = p.name,
                                description = p.descr,
                                type = new NodeType
                                {
                                    typeId = p.nodetype.typeid,
                                    name = p.nodetype.name,
                                    iconUrl = p.nodetype.iconurl,
                                    description = p.nodetype.descr
                                }
                            })
                            .ToList<Node>();
            }
            return nlist;

        }

    }
}
