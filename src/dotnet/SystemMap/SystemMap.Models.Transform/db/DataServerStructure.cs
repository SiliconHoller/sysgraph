using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public class DataServerStructure
    {
        protected List<DataSourceStructure> dblist;


        public DataSourceNodeBase ServerNode { get; set; }
        public List<DataSourceStructure> Databases 
        {
            get
            {
                if (dblist == null) dblist = new List<DataSourceStructure>();
                return dblist;
            }
            set
            {
                dblist = value;
            }
        }
    }
}
