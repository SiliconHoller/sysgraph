using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public class GenericDataSourceNode : DataSourceNodeBase
    {

        public GenericDataSourceNode(string txt, SqlConnectionStringBuilder cbuilder)
            : base(txt, cbuilder)
        {

        }

        protected override void LoadDatabaseObjects()
        {
            //do nothing
        }

        protected override void LoadDatabaseRelationships()
        {
            //do nothing
        }

        protected override void LoadDatabaseAttributes()
        {
            //do nothing
        }

        public override string ToString()
        {
            string baseval = null;
            if (Lineage != null) baseval = Lineage.lineageValue;
            return String.Format("External Reference {0}{1}", baseval, ObjectName);
        }
    }
}
