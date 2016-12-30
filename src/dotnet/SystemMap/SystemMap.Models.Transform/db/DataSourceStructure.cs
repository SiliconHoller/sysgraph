using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public class DataSourceStructure
    {
        public DataSourceNodeBase DataSource { get; set; }
        public List<DataSourceNodeBase> Nodes { get; set; }
        public List<DataConnection> Relationships { get; set; }
    }
}
