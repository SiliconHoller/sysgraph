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
        #region Getters

        /// <summary>
        /// Get Node by name
        /// </summary>
        /// <param name="nodeName">Name of node to find</param>
        /// <returns>Node model, if exists; otherwise, a null value.</returns>
        public Node GetByName(string nodeName)
        {
            Node retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                retval = db.nodes.Where(n => n.name == nodeName)
                                .Select(n => new Node 
                                {
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
                                .FirstOrDefault();
            }
            return retval;

        }

        /// <summary>
        /// Get Node data
        /// </summary>
        /// <param name="nodeid">Node of interest</param>
        /// <returns>Node information, if exists; otherwise, null</returns>
        public Node Get(int nodeid)
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

        /// <summary>
        /// Given a list of node id values (from another filter process, for example), return a collection
        /// of the given records.
        /// </summary>
        /// <param name="nodeIdList">List of node id values</param>
        /// <returns>Collection of node models with the given identities, if they exist; if none found, and empty collection.</returns>
        public IEnumerable<Node> GetListed(IEnumerable<int> nodeIdList)
        {
            List<Node> nlist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nlist = db.nodes
                        .Where(n => nodeIdList.Contains(n.nodeid))
                        .OrderBy(n => n.name)
                        .Select(n => new Node
                        {
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
                        .ToList<Node>();

            }
            return nlist;
        }

        /// <summary>
        /// Return a colleciton of the nodes of a particular type
        /// </summary>
        /// <param name="typeid">Type of interest</param>
        /// <returns>Collection of nodes of the given type; otherwise, an empty collection</returns>
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




        #endregion

        #region Write/Delete ops

        public int AddNode(Node nnode, bool typeadd = false)
        {
            int retval = -1;
            //Check for typeval--if not exists (and typeadd == false) throw exception;
            if (nnode.type == null) throw new Exception("Node type data required");
            TypeService typesvc = new TypeService();
            NodeType ntype = typesvc.GetNodeType(nnode.type.name, typeadd);

            using (SystemMapEntities db = new SystemMapEntities())
            {
                node addnode = new node { name = nnode.name, descr = nnode.description, typeid = ntype.typeId };
                db.nodes.Add(addnode);
                db.SaveChanges();
                retval = addnode.nodeid;
            }
            return retval;
        }

        public void UpdateNode(Node unode)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node update = db.nodes.Where(n => n.nodeid == unode.id).SingleOrDefault();
                update.name = unode.name;
                update.descr = unode.description;
                update.typeid = unode.type.typeId;
                db.SaveChanges();
            }
        }

        public void DeleteNode(int nodeid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node delnode = db.nodes.Where(n => n.nodeid == nodeid).Single();
                db.nodes.Remove(delnode);
                db.SaveChanges();
            }
        }

        #endregion

        #region Attributes

        public int AddAttribute(NodeAttribute natt)
        {
            int retval = -1;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes ndata = new node_attributes
                                            {
                                                name = natt.name,
                                                descr = natt.description,
                                                nodeid = natt.nodeId,
                                                attrtypeid = natt.type.typeId
                                            };
                db.node_attributes.Add(ndata);
                db.SaveChanges();
                retval = ndata.attributeid;
            }
            return retval;
        }

        public IEnumerable<NodeAttribute> GetAttributes(int nodeid)
        {
            List<NodeAttribute> attlist = new List<NodeAttribute>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attlist = db.node_attributes
                            .Where(na => na.nodeid == nodeid)
                            .OrderBy(na => na.name)
                            .Select(na => new NodeAttribute
                            {
                                id = na.attributeid,
                                name = na.name,
                                description = na.descr,
                                type = new AttributeType
                                {
                                    typeId = na.attribute_types.attrtypeid,
                                    name = na.attribute_types.name,
                                    description = na.attribute_types.descr,
                                    iconUrl = na.attribute_types.iconurl
                                }
                            })
                            .ToList<NodeAttribute>();
            }
            return attlist;
        }

        public void UpdateAttribute(NodeAttribute natt)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes urecord = db.node_attributes
                                            .Where(na => na.attributeid == natt.id)
                                            .SingleOrDefault();
                if (urecord != null)
                {
                    urecord.name = natt.name;
                    urecord.descr = natt.description;
                    urecord.attrtypeid = natt.type.typeId;
                    urecord.nodeid = natt.nodeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteAttribute(int nattid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes del = db.node_attributes.Where(na => na.attributeid == nattid).SingleOrDefault();
                if (del != null)
                {
                    db.node_attributes.Remove(del);
                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}
