using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Models.Transform.db.utils;

namespace SystemMap.Models.Transform.db.sqlserver
{
    /// <summary>
    /// Connects to a SQL Server instance using the given connection string builder
    /// and extracts the database structure appropriately.
    /// </summary>
    public class SqlServerInspector : DbInspector
    {
        public SqlServerInspector(SqlConnectionStringBuilder cbuilder)
            : base(cbuilder)
        {

        }

        public override DataServerStructure InitStructure()
        {
            serverStructure = new DataServerStructure();
            return serverStructure;
        }

        public override void LoadData()
        {
            
            
        }

        public override void ReloadData()
        {
            //here's where we get to work
        }
        
        public override bool PersistMap()
        {
            bool retval = false;
            //translate the structure into the SystemMap Services.
            return retval;
        }

        /// <summary>
        /// Using the given SqlConnectionStringBuilder, create a node for the top-level
        /// SQL Server instance
        /// </summary>
        /// <returns></returns>
        protected DataSourceNodeBase CreateServerNode()
        {
            SqlServerInstanceNode server = new SqlServerInstanceNode(connBuilder.DataSource, connBuilder);
            server.LoadMetadata();
            return server;
        }


    }
}
