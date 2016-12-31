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

        public SqlServerTableNode(string tableName, SqlConnectionStringBuilder cbuilder)
            : base(tableName, cbuilder)
        {

        }

        public string Schema { get; set; }

        public string TableName { get; set; }

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
            return String.Format("Table {0}.{1}", Schema, TableName);
        }
    }
}
