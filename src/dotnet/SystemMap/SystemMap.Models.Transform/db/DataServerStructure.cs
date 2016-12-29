using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public class DataServerStructure
    {
        public DataSourceNodeBase ServerNode { get; set; }
        public List<DataSourceStructure> Databases { get; set; }
    }
}
