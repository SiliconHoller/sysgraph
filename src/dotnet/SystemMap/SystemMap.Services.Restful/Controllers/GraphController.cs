using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SystemMap.Entities.service;
using SystemMap.Models;

namespace SystemMap.Services.Restful.Controllers
{
    public class GraphController : ApiController
    {
        // GET: api/Graph
        public AdjacencyList Get()
        {
            GraphService gsvc = new GraphService();
            Dictionary<int, IEnumerable<int>> adjlist = gsvc.GetFullEdgeList();
            return new AdjacencyList(adjlist);
        }

        // GET: api/Graph/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Graph
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Graph/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Graph/5
        public void Delete(int id)
        {
        }
    }
}
