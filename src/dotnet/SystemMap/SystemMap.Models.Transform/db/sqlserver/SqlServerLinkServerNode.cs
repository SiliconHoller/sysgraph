using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db.sqlserver
{
    public class SqlServerLinkServerNode : DataSourceNodeBase
    {

        public SqlServerLinkServerNode(string lsysName, SqlConnectionStringBuilder cbuilder)
            : base(lsysName, cbuilder)
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
