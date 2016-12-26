using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;
using SystemMap.Models;

namespace SystemMap.Entities.service
{
    public class AttributeService
    {
        #region General listings
        
        public IEnumerable<AttributeType> ListTypes()
        {
            List<AttributeType> attList = new List<AttributeType>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attList = db.attribute_types
                            .OrderBy(a => a.name)
                            .Select(a => new AttributeType
                            {
                                typeId = a.attrtypeid,
                                name = a.name,
                                description = a.descr,
                                iconUrl = a.iconurl
                            })
                            .ToList<AttributeType>();
            }
            return attList;
        }

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

        #endregion

        #region Attribute Type Management

        public AttributeType AddType(AttributeType natt)
        {
            AttributeType added = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                int ecount = db.attribute_types
                                .Where(at => at.name == natt.name)
                                .Count();
                if (ecount > 0)
                {
                    added = db.attribute_types
                                .Where(at => at.name == natt.name)
                                .OrderBy(at=>at.attrtypeid)
                                .Select(at => new AttributeType
                                {
                                    typeId = at.attrtypeid,
                                    name = at.name,
                                    description = at.descr,
                                    iconUrl = at.iconurl
                                })
                                .FirstOrDefault();
                }
                else
                {
                    attribute_types nrec = new attribute_types { name = natt.name, descr = natt.description, iconurl = natt.iconUrl };
                    db.attribute_types.Add(nrec);
                    db.SaveChanges();
                    added = new AttributeType { typeId = nrec.attrtypeid, name = nrec.name, description = nrec.descr, iconUrl = nrec.iconurl };
                }
            }
            return added;
        }

        public void UpdateType(AttributeType udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attribute_types urec = db.attribute_types
                                            .Where(at => at.attrtypeid == udata.typeId)
                                            .SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.iconurl = udata.iconUrl;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteType(int atypeid)
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

        #region Node attributes

        public IEnumerable<NodeAttribute> GetNodeAttributes(int nodeid)
        {
            List<NodeAttribute> attList = new List<NodeAttribute>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attList = db.node_attributes
                            .Where(natt => natt.nodeid == nodeid)
                            .Select(natt => new NodeAttribute
                            {
                                id = natt.attributeid,
                                name = natt.name,
                                description = natt.descr,
                                nodeVal = natt.nodeval,
                                type = new AttributeType
                                {
                                    typeId = natt.attribute_types.attrtypeid,
                                    name = natt.attribute_types.name,
                                    description = natt.attribute_types.descr,
                                    iconUrl = natt.attribute_types.iconurl
                                }
                            })
                            .ToList<NodeAttribute>();
            }
            return attList;
        }

        public NodeAttribute AddNodeAttribute(NodeAttribute natt)
        {
            NodeAttribute retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes nrec = new node_attributes
                                            {
                                                name = natt.name,
                                                descr = natt.description,
                                                attrtypeid = natt.type.typeId
                                            };
                db.node_attributes.Add(nrec);
                db.SaveChanges();
                retval = new NodeAttribute
                {
                    id = nrec.attributeid,
                    name = nrec.name,
                    description = nrec.descr
                };
                retval.type = GetAttributeType(nrec.attrtypeid);
            }
            return retval;
        }

        public void UpdateNodeAttribute(NodeAttribute udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes urec = db.node_attributes
                                        .Where(na => na.attributeid == udata.id)
                                        .SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.attrtypeid = udata.type.typeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteNodeAttribute(int nattid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_attributes delrec = db.node_attributes
                                            .Where(na => na.attributeid == nattid)
                                            .SingleOrDefault();
                if (delrec != null)
                {
                    db.node_attributes.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region Edge attributes

        public IEnumerable<EdgeAttribute> GetEdgeAttributes(int edgeid)
        {
            List<EdgeAttribute> attList = new List<EdgeAttribute>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                attList = db.edge_attributes
                            .Where(eatt => eatt.edgeid == edgeid)
                            .Select(eatt => new EdgeAttribute
                            {
                                id = eatt.attributeid,
                                name = eatt.name,
                                description = eatt.descr,
                                edgeVal = eatt.edgeval,
                                type = new AttributeType
                                {
                                    typeId = eatt.attribute_types.attrtypeid,
                                    name = eatt.attribute_types.name,
                                    description = eatt.attribute_types.descr,
                                    iconUrl = eatt.attribute_types.iconurl
                                }
                            })
                            .ToList<EdgeAttribute>();
            }
            return attList;
        }

        public EdgeAttribute AddEdgeAttribute(EdgeAttribute eatt)
        {
            EdgeAttribute retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_attributes erec = new edge_attributes
                {
                    name = eatt.name,
                    descr = eatt.description,
                    attrtypeid = eatt.type.typeId
                };
                db.edge_attributes.Add(erec);
                db.SaveChanges();
                retval = new EdgeAttribute
                {
                    id = erec.attributeid,
                    name = erec.name,
                    description = erec.descr
                };
                retval.type = GetAttributeType(erec.attrtypeid);
            }
            return retval;
        }

        public void UpdateNodeAttribute(EdgeAttribute udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_attributes urec = db.edge_attributes
                                        .Where(ea => ea.attributeid == udata.id)
                                        .SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.attrtypeid = udata.type.typeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteEdgeAttribute(int eattid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_attributes delrec = db.edge_attributes
                                            .Where(ea => ea.attributeid == eattid)
                                            .SingleOrDefault();
                if (delrec != null)
                {
                    db.edge_attributes.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }


        #endregion

    }
}
