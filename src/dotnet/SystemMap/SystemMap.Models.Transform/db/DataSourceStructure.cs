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
        public List<DataSourceNodeBase> Tables { get; set; }
        public List<DataSourceNodeBase> Views { get; set; }
        public List<DataSourceNodeBase> Procedures { get; set; }
        public List<DataSourceNodeBase> Functions { get; set; }
        public List<DataSourceNodeBase> LinkServers { get; set; }
        public List<DataConnection> Relationships { get; set; }
    }
}
