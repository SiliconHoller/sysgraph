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
    /// Provides CRUD and lookup services for documentation links
    /// </summary>
    public class DocumentService
    {

        #region Node Documents

        public IEnumerable<Documentation> GetNodeDocs(int nodeid)
        {
            List<Documentation> docList = new List<Documentation>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                docList = db.node_docs
                            .Where(nd => nd.nodeid == nodeid)
                            .OrderBy(nd => nd.name)
                            .Select(nd => new Documentation
                            {
                                documentationId = nd.node_docid,
                                name = nd.name,
                                description = nd.descr,
                                url = nd.docurl,
                                docTypeId = nd.doctypeid
                            })
                            .ToList<Documentation>();
                TypeService tsvc = new TypeService();
                IEnumerable<DocType> typelist = tsvc.GetDocTypes();
                foreach (Documentation doc in docList)
                {
                    doc.documentType = typelist.Where(t => t.typeId == doc.docTypeId).FirstOrDefault();
                }
            }
            return docList;
        }

        public Documentation AddNodeDoc(Documentation nd)
        {
            Documentation retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_docs ndoc = new node_docs { name = nd.name, doctypeid = nd.docTypeId, descr = nd.description, docurl = nd.url, nodeid = nd.componentId };
                db.node_docs.Add(ndoc);
                db.SaveChanges();
                retval = new Documentation
                {
                    documentationId = ndoc.node_docid,
                    name = ndoc.name,
                    description = ndoc.descr,
                    url = ndoc.docurl,
                    docTypeId = ndoc.doctypeid,
                    documentType = new DocType
                    {
                        typeId = ndoc.doctypeid,
                        name = ndoc.doc_type.typename,
                        description = ndoc.doc_type.descr,
                        iconUrl = ndoc.doc_type.iconurl
                    }
                };
            }
            return retval;
        }

        public void UpdateNodeDoc(Documentation udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_docs urec = db.node_docs.Where(d => d.node_docid == udata.documentationId).SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.docurl = udata.url;
                    urec.doctypeid = udata.docTypeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteNodeDoc(int nodedocid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                node_docs delrec = db.node_docs.Where(d => d.node_docid == nodedocid).SingleOrDefault();
                if (delrec != null)
                {
                    db.node_docs.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region Edge Documents

        public IEnumerable<Documentation> GetEdgeDocs(int edgeid)
        {
            List<Documentation> docList = new List<Documentation>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                docList = db.edge_docs
                            .Where(ed => ed.edgeid == edgeid)
                            .OrderBy(ed => ed.name)
                            .Select(ed => new Documentation
                            {
                                documentationId = ed.edge_docid,
                                name = ed.name,
                                description = ed.descr,
                                url = ed.docurl,
                                docTypeId = ed.doctypeid
                            })
                            .ToList<Documentation>();
                TypeService tsvc = new TypeService();
                IEnumerable<DocType> typelist = tsvc.GetDocTypes();
                foreach (Documentation doc in docList)
                {
                    doc.documentType = typelist.Where(t => t.typeId == doc.docTypeId).FirstOrDefault();
                }
            }
            return docList;
        }

        public Documentation AddEdgeDoc(Documentation edoc)
        {
            Documentation retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_docs ndoc = new edge_docs { name = edoc.name, doctypeid = edoc.docTypeId, descr = edoc.description, docurl = edoc.url, edgeid = edoc.componentId };
                db.edge_docs.Add(ndoc);
                db.SaveChanges();
                retval = new Documentation
                {
                    documentationId = ndoc.edge_docid,
                    name = ndoc.name,
                    description = ndoc.descr,
                    url = ndoc.docurl,
                    docTypeId = ndoc.doctypeid,
                    documentType = new DocType
                    {
                        typeId = ndoc.doctypeid,
                        name = ndoc.doc_type.typename,
                        description = ndoc.doc_type.descr,
                        iconUrl = ndoc.doc_type.iconurl
                    }
                };
            }
            return retval;
        }

        public void UpdateEdgeDoc(Documentation udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_docs urec = db.edge_docs.Where(d => d.edge_docid == udata.documentationId).SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.docurl = udata.url;
                    urec.doctypeid = udata.docTypeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteEdgeDoc(int edgedocid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge_docs delrec = db.edge_docs.Where(d => d.edge_docid == edgedocid).SingleOrDefault();
                if (delrec != null)
                {
                    db.edge_docs.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }


        #endregion

        #region Process Documents

        public IEnumerable<Documentation> GetProcessDocs(int procid)
        {
            List<Documentation> docList = new List<Documentation>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                docList = db.process_docs
                            .Where(pd => pd.processid == procid)
                            .OrderBy(pd => pd.name)
                            .Select(pd => new Documentation
                            {
                                documentationId = pd.process_docid,
                                name = pd.name,
                                description = pd.descr,
                                url = pd.docurl,
                                docTypeId = pd.doctypeid
                            })
                            .ToList<Documentation>();
                TypeService tsvc = new TypeService();
                IEnumerable<DocType> typelist = tsvc.GetDocTypes();
                foreach (Documentation doc in docList)
                {
                    doc.documentType = typelist.Where(t => t.typeId == doc.docTypeId).FirstOrDefault();
                }
            }
            return docList;
        }

        public Documentation AddProcessDoc(Documentation pdoc)
        {
            Documentation retval = null;
            using (SystemMapEntities db = new SystemMapEntities())
            {
                process_docs ndoc = new process_docs { name = pdoc.name, doctypeid = pdoc.docTypeId, descr = pdoc.description, docurl = pdoc.url, processid = pdoc.componentId };
                db.process_docs.Add(ndoc);
                db.SaveChanges();
                retval = new Documentation
                {
                    documentationId = ndoc.process_docid,
                    name = ndoc.name,
                    description = ndoc.descr,
                    url = ndoc.docurl,
                    docTypeId = ndoc.doctypeid,
                    documentType = new DocType
                    {
                        typeId = ndoc.doctypeid,
                        name = ndoc.doc_type.typename,
                        description = ndoc.doc_type.descr,
                        iconUrl = ndoc.doc_type.iconurl
                    }
                };
            }
            return retval;
        }

        public void UpdateProcessDoc(Documentation udata)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                process_docs urec = db.process_docs.Where(d => d.process_docid == udata.documentationId).SingleOrDefault();
                if (urec != null)
                {
                    urec.name = udata.name;
                    urec.descr = udata.description;
                    urec.docurl = udata.url;
                    urec.doctypeid = udata.docTypeId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteProcessDoc(int pdocid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                process_docs delrec = db.process_docs.Where(d => d.process_docid == pdocid).SingleOrDefault();
                if (delrec != null)
                {
                    db.process_docs.Remove(delrec);
                    db.SaveChanges();
                }
            }
        }



        #endregion
    }
}
