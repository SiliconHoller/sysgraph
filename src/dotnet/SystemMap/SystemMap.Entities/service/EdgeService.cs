﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;
using SystemMap.Models;

namespace SystemMap.Entities.service
{
    /// <summary>
    /// Provides CRUD and lookup services for Edge/Connector data
    /// </summary>
    public class EdgeService
    {

        #region Getters

        /// <summary>
        /// Return a list of edges from the given node id.
        /// </summary>
        /// <param name="nodeid">Node of interest</param>
        /// <returns>Collection of edges originating from the given node, if they exist; otherwise, an empty list.</returns>
        public IEnumerable<Edge> GetEdgesFrom(int nodeid)
        {
            List<Edge> elist = new List<Edge>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                elist = db.edges
                            .Where(e => e.from_node == nodeid)
                            .Select(e => new Edge
                            {
                                id = e.edgeid,
                                name = e.name,
                                description = e.descr,
                                fromNodeId = e.from_node,
                                toNodeId = e.to_node,
                                type = new EdgeType
                                {
                                    typeId = e.edgetypeid,
                                    name = e.edgetype.name,
                                    iconUrl = e.edgetype.iconurl
                                }
                            })
                            .ToList<Edge>();
            }
            return elist;
        }

        /// <summary>
        /// Return a list of edges to the given node
        /// </summary>
        /// <param name="nodeid">node of interest</param>
        /// <returns>Collection of edges terminating at the given node, if they exist; otherwise, an empty list.</returns>
        public IEnumerable<Edge> GetEdgesTo(int nodeid)
        {
            List<Edge> elist = new List<Edge>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                elist = db.edges
                            .Where(e => e.to_node == nodeid)
                            .Select(e => new Edge
                            {
                                id = e.edgeid,
                                name = e.name,
                                description = e.descr,
                                fromNodeId = e.from_node,
                                toNodeId = e.to_node,
                                type = new EdgeType
                                {
                                    typeId = e.edgetypeid,
                                    name = e.edgetype.name,
                                    iconUrl = e.edgetype.iconurl
                                }
                            })
                            .ToList<Edge>();
            }
            return elist;
        }

        /// <summary>
        /// Given a list of edges (from another filter selection), return Edge data for each in a collection
        /// </summary>
        /// <param name="eidList">Collection of edge identity values</param>
        /// <returns>Collection of edge model data for each record, if it exists; otherwise, an empty collection.</returns>
        public IEnumerable<Edge> GetListedEdges(IEnumerable<int> eidList)
        {
            List<Edge> edgeList = new List<Edge>();
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edgeList = db.edges.Where(e => eidList.Contains(e.edgeid))
                            .OrderBy(e => e.name)
                            .Select(e => new Edge
                            {
                                id = e.edgeid,
                                name = e.name,
                                description = e.descr,
                                fromNodeId = e.from_node,
                                toNodeId = e.to_node,
                                type = new EdgeType
                                {
                                    typeId = e.edgetypeid,
                                    name = e.edgetype.name,
                                    iconUrl = e.edgetype.iconurl
                                }
                            })
                            .ToList<Edge>();
            }
            return edgeList;
        }

        #endregion

        #region Write/update operations

        /// <summary>
        /// Add a new edge given the Connector model
        /// </summary>
        /// <param name="conn">Connector model containing edge information</param>
        /// <returns>identity value of the new edge record; otherwise, -1.</returns>
        public int AddEdge(Edge conn, bool typeadd = false)
        {
            int retval = -1;
            if (conn.type == null) throw new Exception("Edge type data required");
            TypeService tsvc = new TypeService();
            EdgeType etype = tsvc.GetEdgeType(conn.type.name, typeadd);
            using (SystemMapEntities db = new SystemMapEntities())
            {
                //check that an existing edge (u, v, name) is not already there)
                edge curredge = db.edges.Where(e => e.from_node == conn.fromNodeId && e.to_node == conn.toNodeId && e.name == conn.name).FirstOrDefault();
                if (curredge == null)
                {
                    curredge = new edge { name = conn.name, edgetypeid = etype.typeId, descr = conn.description, from_node = conn.fromNodeId, to_node = conn.toNodeId };
                    db.edges.Add(curredge);
                    db.SaveChanges();
                }
                retval = curredge.edgeid;
            }
            return retval;
        }

        /// <summary>
        /// Update edge information
        /// </summary>
        /// <param name="conn">Connector model containing the updated information</param>
        public void UpdateEdge(Edge conn)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge uedge = db.edges.Where(e => e.edgeid == conn.id).SingleOrDefault();
                if (uedge != null)
                {
                    uedge.name = conn.name;
                    uedge.descr = conn.description;
                    uedge.edgetypeid = conn.type.typeId;
                    uedge.from_node = conn.fromNodeId;
                    uedge.to_node = conn.toNodeId;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remove the given edge from the system
        /// </summary>
        /// <param name="edgeid"></param>
        public void RemoveEdge(int edgeid)
        {
            using (SystemMapEntities db = new SystemMapEntities())
            {
                edge deledge = db.edges.Where(e => e.edgeid == edgeid).SingleOrDefault();
                if (deledge != null)
                {
                    db.edges.Remove(deledge);
                    db.SaveChanges();
                }
            }
        }

        #endregion

    }
}
