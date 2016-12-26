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
                retval.type = new TypeService().GetAttributeType(nrec.attrtypeid);
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
                retval.type = new TypeService().GetAttributeType(erec.attrtypeid);
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
