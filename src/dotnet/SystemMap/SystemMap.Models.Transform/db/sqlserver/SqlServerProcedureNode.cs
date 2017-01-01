using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db.sqlserver
{
    public class SqlServerProcedureNode : DataSourceNodeBase
    {

        public SqlServerProcedureNode(string procName, SqlConnectionStringBuilder cbuilder)
            : base(procName, cbuilder)
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
            return String.Format("Stored Procedure {0}.{1}", Schema, ObjectName);
        }
    }
}
