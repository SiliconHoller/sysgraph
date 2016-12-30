using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db.sqlserver
{
    public class SqlServerTableNode : DataSourceNodeBase
    {
        protected string schema;
        protected string tableName;

        public SqlServerTableNode(string schema, string tableName, SqlConnectionStringBuilder cbuilder)
            : base(String.Format("{0}.{1}",schema,tableName), cbuilder)
        {
            this.schema = schema;
            this.tableName = tableName;
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

        public override string ToString()
        {
            return String.Format("Table {0}.{1}", schema, tableName);
        }
    }
}
