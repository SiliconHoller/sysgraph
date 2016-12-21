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
    /// Provides CRUD and lookup services for various type data
    /// </summary>
    public class TypeService
    {
        #region NodeType data

        /// <summary>
        /// Get the type associated with the given information.  If typeadd is true, then add those values to the node types if not found.
        /// </summary>
        /// <param name="typeid">identifier of the node type</param>
        /// <param name="typename">Name for the node type</param>
        /// <param name="typeadd">default is false.  If not found add the typename to the nodetypes.</param>
        /// <returns></returns>
        public NodeType GetNodeType(int typeid, string typename, bool typeadd = false)
        {
            NodeType ntype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                ntype = db.nodetypes
                            .Where(nt => nt.typeid == typeid)
                            .Select(nt => new NodeType
                            {
                                typeId = nt.typeid,
                                name = nt.name,
                                description = nt.descr,
                                iconUrl = nt.iconurl
                            })
                            .SingleOrDefault();

                if (ntype == null && typeadd && !String.IsNullOrEmpty(typename) && !String.IsNullOrWhiteSpace(typename))
                {
                    //Go ahead and add it
                    nodetype addtype = new nodetype { name = typename };
                    db.nodetypes.Add(addtype);
                    db.SaveChanges();
                    ntype = new NodeType { name = typename, typeId = addtype.typeid };
                }
            }
            return ntype;
        }


        /// <summary>
        /// Return a collection of node types
        /// </summary>
        /// <returns>Collection of node types, sorted alphabetically, if they exist; otherwise, an empty collection</returns>
        public IEnumerable<NodeType> GetNodeTypes()
        {
            List<NodeType> tlist = new List<NodeType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                tlist = db.nodetypes.OrderBy(t => t.name)
                            .Select(t => new NodeType
                            {
                                typeId = t.typeid,
                                name = t.name,
                                description = t.descr,
                                iconUrl = t.iconurl
                            })
                            .ToList<NodeType>();
            }
            return tlist;
        }

        /// <summary>
        /// Add a new NodeType entry to storage
        /// </summary>
        /// <param name="ntype"></param>
        /// <returns></returns>
        public NodeType AddNodeType(NodeType ntype)
        {
            NodeType typeval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that we don't already have this name
                int ecount = db.nodetypes.Where(n => n.name == ntype.name).Count();
                if (ecount == 0)
                {
                    //Go ahead and add it
                    nodetype addtype = new nodetype { name = ntype.name, descr = ntype.description, iconurl = ntype.iconUrl };
                    db.nodetypes.Add(addtype);
                    db.SaveChanges();
                    typeval = new NodeType { typeId = addtype.typeid, name = addtype.name, description = addtype.descr, iconUrl = addtype.iconurl };
                }
                else
                {
                    typeval = db.nodetypes
                                .Where(n => n.name == ntype.name)
                                .Select(n => new NodeType
                                {
                                    typeId = n.typeid,
                                    name = n.name,
                                    description = n.descr,
                                    iconUrl = n.iconurl
                                })
                                .FirstOrDefault();
                }
            }
            return typeval;
        }

        public void UpdateNodeType(NodeType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nodetype utype = db.nodetypes
                                    .Where(nt => nt.typeid == udata.typeId)
                                    .SingleOrDefault();
                if (utype != null)
                {
                    utype.name = udata.name;
                    utype.descr = udata.description;
                    utype.iconurl = udata.iconUrl;
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region EdgeType data

        public EdgeType GetEdgeType(int typeid, string typename, bool typeadd = false)
        {
            EdgeType etype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                etype = db.edgetypes
                            .Where(et => et.name == typename)
                            .Select(et => new EdgeType
                            {
                                typeId = et.edgetypeid,
                                name = et.name,
                                description = et.descr,
                                iconUrl = et.iconurl
                            })
                            .SingleOrDefault();
                if (etype == null && typeadd && !String.IsNullOrEmpty(typename) && !String.IsNullOrWhiteSpace(typename))
                {
                    edgetype netype = new edgetype { name = typename };
                    db.edgetypes.Add(netype);
                    db.SaveChanges();
                    etype = new EdgeType { name = typename, typeId = netype.edgetypeid };
                }
            }
            return etype;
        }

        public IEnumerable<EdgeType> GetEdgeTypes()
        {
            List<EdgeType> tlist = new List<EdgeType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                tlist = db.edgetypes.OrderBy(et => et.name)
                        .Select(et => new EdgeType
                        {
                            typeId = et.edgetypeid,
                            name = et.name, 
                            description = et.descr,
                            iconUrl = et.iconurl
                        })
                        .ToList<EdgeType>();
            }
            return tlist;
        }

        public EdgeType AddEdgeType(EdgeType etype)
        {
            EdgeType typeval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that we don't already have this name
                int ecount = db.edgetypes.Where(n => n.name == etype.name).Count();
                if (ecount == 0)
                {
                    //Go ahead and add it
                    edgetype addtype = new edgetype { name = etype.name, descr = etype.description, iconurl = etype.iconUrl };
                    db.edgetypes.Add(addtype);
                    db.SaveChanges();
                    typeval = new EdgeType { typeId = addtype.edgetypeid, name = addtype.name, description = addtype.descr, iconUrl = addtype.iconurl };
                }
                else
                {
                    typeval = db.edgetypes
                                .Where(n => n.name == etype.name)
                                .Select(n => new EdgeType
                                {
                                    typeId = n.edgetypeid,
                                    name = n.name,
                                    description = n.descr,
                                    iconUrl = n.iconurl
                                })
                                .FirstOrDefault();
                }
            }
            return typeval;
        }

        public void UpdateEdgeType(EdgeType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edgetype utype = db.edgetypes
                                    .Where(et => et.edgetypeid == udata.typeId)
                                    .SingleOrDefault();
                if (utype != null)
                {
                    utype.name = udata.name;
                    utype.descr = udata.description;
                    utype.iconurl = udata.iconUrl;
                    db.SaveChanges();
                }
            }
        }

        #endregion
    }
}
