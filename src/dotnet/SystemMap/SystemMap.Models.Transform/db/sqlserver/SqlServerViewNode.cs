using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db.sqlserver
{


    public class SqlServerViewNode : DataSourceNodeBase
    {




        public SqlServerViewNode(string viewName, SqlConnectionStringBuilder cbuilder)
            : base(viewName, cbuilder)
        {

        }

        
        protected override void LoadDatabaseObjects()
        {

        }

        protected override void LoadDatabaseRelationships()
        {

        }

        protected override void LoadDatabaseAttributes()
        {

        }

        public override string ToString()
        {
            return String.Format("View {0}.{1}", Schema, ObjectName);
        }
    }
}
