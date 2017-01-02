using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db.sqlserver
{
    public class SqlServerTriggerNode : DataSourceNodeBase
    {
        public SqlServerTriggerNode(string triggerName, SqlConnectionStringBuilder cbuilder)
            : base(triggerName, cbuilder)
        {

        }

        protected override void LoadDatabaseObjects()
        {
            throw new NotImplementedException();
        }

        protected override void LoadDatabaseRelationships()
        {
            throw new NotImplementedException();
        }

        protected override void LoadDatabaseAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
