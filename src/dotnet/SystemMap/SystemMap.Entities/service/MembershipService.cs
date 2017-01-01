using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;
using SystemMap.Models;

namespace SystemMap.Entities.service
{
    public class MembershipService
    {

        #region Node Membership

        /// <summary>
        /// Return a collection of the nodes which are classified as containers of this node
        /// </summary>
        /// <param name="nodeid">Node of interest</param>
        /// <returns>Collection of container nodes, if they exist; otherwise an empty collection </returns>
        public IEnumerable<Node> GetNodeContainers(int nodeid)
        {
            List<Node> clist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                clist = db.node_membership
                            .Where(nm => nm.membernode_id == nodeid)
                            .Join(db.nodes, a => a.groupnode_id, b => b.nodeid, (a, b) => new { memtypeid = a.memtypeid, container = b })
                            .Join(db.membership_types, a => a.memtypeid, b => b.memtypeid, (a, b) => new { container = a.container, mtype = b })
                            .Select(n => new Node
                            {
                                id = n.container.nodeid,
                                name = n.container.name,
                                description = n.container.descr,
                                memType = n.mtype != null ? new MembershipType { typeId = n.mtype.memtypeid, name = n.mtype.typename, iconUrl = n.mtype.iconurl } : null,
                            })
                            .ToList<Node>();
            }
            return clist;
        }

        /// <summary>
        /// Return a collection of nodes which are part of the membership group as the given node id.
        /// </summary>
        /// <param name="nodeid">Identifier for node of interest</param>
        /// <returns>Collection of sibling nodes, if they exist; otherwise, an empty list</returns>
        public IEnumerable<Node> GetNodeSiblings(int nodeid)
        {
            List<Node> nlist = new List<Node>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                nlist = db.node_membership
                            .Where(nm => nm.membernode_id == nodeid)
                            .Join(db.node_membership, a => a.groupnode_id, b => b.groupnode_id, (a, b) => b)
                            .Join(db.nodes, a => a.membernode_id, b => b.nodeid, (a, b) => b)
                            .OrderBy(n => n.name)
                            .Select(s => new Node
                            {
                                id = s.nodeid,
                                name = s.name,
                                description = s.descr,
                                type = new NodeType
                                {
                                    typeId = s.nodetype.typeid,
                                    name = s.nodetype.name,
                                    iconUrl = s.nodetype.iconurl,
                                    description = s.nodetype.descr
                                }
                            })
                            .ToList<Node>();
            }
            return nlist;
        }

        #endregion
    }
}
