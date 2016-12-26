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
    public class TypeService : IDisposable
    {
        #region NodeType data

        /// <summary>
        /// Get the type associated with the given information.  If typeadd is true, then add those values to the node types if not found.
        /// </summary>
        /// <param name="typeid">identifier of the node type</param>
        /// <param name="typename">Name for the node type</param>
        /// <param name="typeadd">default is false.  If not found add the typename to the nodetypes.</param>
        /// <returns></returns>
        public NodeType GetNodeType(string typename, bool typeadd = false)
        {
            NodeType ntype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                ntype = db.nodetypes
                            .Where(nt => nt.name == typename)
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

        public EdgeType GetEdgeType(string typename, bool typeadd = false)
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

        #region AttributeType data

        public AttributeType GetAttributeType(int attrid)
        {
            AttributeType retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                retval = db.attribute_types
                            .Where(at => at.attrtypeid == attrid)
                            .Select(at => new AttributeType
                            {
                                typeId = at.attrtypeid,
                                name = at.name,
                                description = at.descr,
                                iconUrl = at.iconurl
                            })
                            .SingleOrDefault();
            }
            return retval;
        }

        public AttributeType GetAttributeType(string typename, bool typeadd = false)
        {
            AttributeType atype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                atype = db.attribute_types
                            .Where(at => at.name == typename)
                            .Select(at => new AttributeType
                            {
                                typeId = at.attrtypeid,
                                name = at.name,
                                description = at.descr,
                                iconUrl = at.iconurl
                            })
                            .SingleOrDefault();
                if (atype == null && typeadd && !String.IsNullOrEmpty(typename) && !String.IsNullOrWhiteSpace(typename))
                {
                    attribute_types natype = new attribute_types { name = typename };
                    db.attribute_types.Add(natype);
                    db.SaveChanges();
                    atype = new AttributeType { typeId = natype.attrtypeid, name = typename };
                }
            }
            return atype;
        }

        public IEnumerable<AttributeType> GetAttributeTypes()
        {
            List<AttributeType> alist = new List<AttributeType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                alist = db.attribute_types
                            .OrderBy(at => at.name)
                            .Select(at => new AttributeType
                            {
                                typeId = at.attrtypeid,
                                name = at.name, 
                                description = at.descr,
                                iconUrl = at.iconurl
                            })
                            .ToList<AttributeType>();
            }
            return alist;
        }

        public AttributeType AddAttributeType(AttributeType atype)
        {
            AttributeType typeval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that we don't already have this name
                int ecount = db.attribute_types.Where(n => n.name == atype.name).Count();
                if (ecount == 0)
                {
                    //Go ahead and add it
                    attribute_types addtype = new attribute_types { name = atype.name, descr = atype.description, iconurl = atype.iconUrl };
                    db.attribute_types.Add(addtype);
                    db.SaveChanges();
                    typeval = new AttributeType { typeId = addtype.attrtypeid, name = addtype.name, description = addtype.descr, iconUrl = addtype.iconurl };
                }
                else
                {
                    typeval = db.attribute_types
                                .Where(n => n.name == atype.name)
                                .Select(n => new AttributeType
                                {
                                    typeId = n.attrtypeid,
                                    name = n.name,
                                    description = n.descr,
                                    iconUrl = n.iconurl
                                })
                                .FirstOrDefault();
                }
            }
            return typeval;
        }

        public void UpdateAttributeType(AttributeType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attribute_types utype = db.attribute_types
                                    .Where(at => at.attrtypeid == udata.typeId)
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

        public void DeleteAttributeType(int atypeid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attribute_types delrec = db.attribute_types.Where(at => at.attrtypeid == atypeid).SingleOrDefault();
                if (delrec != null)
                {
                    db.attribute_types.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region MembershipType data

        public MembershipType GetMembershipType(string typename, bool typeadd = false)
        {
            MembershipType mtype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                mtype = db.membership_types
                            .Where(mt => mt.typename == typename)
                            .Select(mt => new MembershipType
                            {
                                typeId = mt.memtypeid,
                                name = mt.typename,
                                description = mt.descr,
                                iconUrl = mt.iconurl
                            })
                            .SingleOrDefault();
                if (mtype == null && typeadd && !String.IsNullOrEmpty(typename) && !String.IsNullOrWhiteSpace(typename))
                {
                    membership_types natype = new membership_types { typename = typename };
                    db.membership_types.Add(natype);
                    db.SaveChanges();
                    mtype = new MembershipType { typeId = natype.memtypeid, name = typename };
                }
            }
            return mtype;
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            List<MembershipType> mlist = new List<MembershipType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                mlist = db.membership_types
                            .OrderBy(mt => mt.typename)
                            .Select(mt => new MembershipType
                            {
                                typeId = mt.memtypeid,
                                name = mt.typename,
                                description = mt.descr,
                                iconUrl = mt.iconurl
                            })
                            .ToList<MembershipType>();
            }
            return mlist;
        }

        public MembershipType AddMembershipType(MembershipType mtype)
        {
            MembershipType typeval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that we don't already have this name
                int ecount = db.membership_types.Where(n => n.typename == mtype.name).Count();
                if (ecount == 0)
                {
                    //Go ahead and add it
                    membership_types addtype = new membership_types { typename = mtype.name, descr = mtype.description, iconurl = mtype.iconUrl };
                    db.membership_types.Add(addtype);
                    db.SaveChanges();
                    typeval = new MembershipType { typeId = addtype.memtypeid, name = addtype.typename, description = addtype.descr, iconUrl = addtype.iconurl };
                }
                else
                {
                    typeval = db.membership_types
                                .Where(n => n.typename == mtype.name)
                                .Select(n => new MembershipType
                                {
                                    typeId = n.memtypeid,
                                    name = n.typename,
                                    description = n.descr,
                                    iconUrl = n.iconurl
                                })
                                .FirstOrDefault();
                }
            }
            return typeval;
        }


        public void UpdateMembershipType(MembershipType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                membership_types utype = db.membership_types
                                    .Where(mt => mt.memtypeid == udata.typeId)
                                    .SingleOrDefault();
                if (utype != null)
                {
                    utype.typename = udata.name;
                    utype.descr = udata.description;
                    utype.iconurl = udata.iconUrl;
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region DocType data

        public DocType GetDocType(string typename, bool typeadd = false)
        {
            DocType dtype = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                dtype = db.doc_type
                            .Where(dt => dt.typename == typename)
                            .Select(dt => new DocType
                            {
                                typeId = dt.doctypeid,
                                name = dt.typename,
                                description = dt.descr,
                                iconUrl = dt.iconurl
                            })
                            .SingleOrDefault();
                if (dtype == null && typeadd && !String.IsNullOrEmpty(typename) && !String.IsNullOrWhiteSpace(typename))
                {
                    doc_type natype = new doc_type { typename = typename };
                    db.doc_type.Add(natype);
                    db.SaveChanges();
                    dtype = new DocType { typeId = natype.doctypeid, name = typename };
                }
            }
            return dtype;
        }

        public IEnumerable<DocType> GetDocTypes()
        {
            List<DocType> dlist = new List<DocType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                dlist = db.doc_type
                            .OrderBy(dt => dt.typename)
                            .Select(dt => new DocType
                            {
                                typeId = dt.doctypeid,
                                name = dt.typename,
                                description = dt.descr,
                                iconUrl = dt.iconurl
                            })
                            .ToList<DocType>();
            }
            return dlist;
        }

        public DocType AddDocType(DocType dtype)
        {
            DocType typeval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that we don't already have this name
                int ecount = db.doc_type.Where(n => n.typename == dtype.name).Count();
                if (ecount == 0)
                {
                    //Go ahead and add it
                    doc_type addtype = new doc_type { typename = dtype.name, descr = dtype.description, iconurl = dtype.iconUrl };
                    db.doc_type.Add(addtype);
                    db.SaveChanges();
                    typeval = new DocType { typeId = addtype.doctypeid, name = addtype.typename, description = addtype.descr, iconUrl = addtype.iconurl };
                }
                else
                {
                    typeval = db.doc_type
                                .Where(n => n.typename == dtype.name)
                                .Select(n => new DocType
                                {
                                    typeId = n.doctypeid,
                                    name = n.typename,
                                    description = n.descr,
                                    iconUrl = n.iconurl
                                })
                                .FirstOrDefault();
                }
            }
            return typeval;
        }

        public void UpdateDocType(DocType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                doc_type utype = db.doc_type
                                    .Where(dt => dt.doctypeid == udata.typeId)
                                    .SingleOrDefault();
                if (utype != null)
                {
                    utype.typename = udata.name;
                    utype.descr = udata.description;
                    utype.iconurl = udata.iconUrl;
                    db.SaveChanges();
                }
            }
        }

        #endregion

        public void Dispose()
        {
            //nothing to do at the moment
        }
    }
}
