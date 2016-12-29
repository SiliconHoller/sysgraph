using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public class DataConnection
    {
        public int EdgeId { get; set; }
        public Enum ConnectionType { get; set; }
        public DataSourceNodeBase StartNode { get; set; }
        public DataSourceNodeBase EndNode { get; set; }

    }
}
