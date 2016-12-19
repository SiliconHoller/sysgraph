using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Models;

namespace SystemMap.Entities.service
{
    /// <summary>
    /// Provides CRUD and lookup services for Edge/Connector data
    /// </summary>
    public class EdgeService
    {

        #region Getters
        public IEnumerable<Connector> GetEdgesFrom(int nodeid)
        {
            List<Connector> elist = new List<Connector>();

            return elist;
        }

        public IEnumerable<Connector> GetEdgesTo(int nodeid)
        {
            List<Connector> elist = new List<Connector>();

            return elist;
        }

        #endregion

    }
}
