using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Models.Transform.util;

namespace SystemMap.Models.Transform.db
{
    public class DataConnection
    {
        public int EdgeId { get; set; }
        public Enum ConnectionType { get; set; }
        public DataSourceNodeBase StartNode { get; set; }
        public DataSourceNodeBase EndNode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return String.Format("{0}{1}", ConnectionType != null ? EnumParser.GetValueName(ConnectionType) + " " : "", Name);
        }
    }
}
