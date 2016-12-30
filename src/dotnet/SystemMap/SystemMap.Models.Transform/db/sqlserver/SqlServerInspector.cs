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
            serverStructure.ServerNode = CreateServerNode();
            return serverStructure;
        }

        public override void LoadData()
        {
            if (serverStructure.Databases == null || serverStructure.Databases.Count == 0) ReloadData();
            
        }

        public override void ReloadData()
        {
            if (serverStructure == null) InitStructure();
            //here's where we get to work
            serverStructure.Databases = new List<DataSourceStructure>();
            serverStructure.ServerNode.LoadSubNodes();
            foreach (DataSourceNodeBase dbnode in serverStructure.ServerNode.Nodes)
            {
                DataSourceStructure dbstruct = new DataSourceStructure { DataSource = dbnode };
                serverStructure.Databases.Add(dbstruct);
            }

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



        public override void LoadDataSource(DataSourceStructure dbstruct)
        {
            dbstruct.DataSource.LoadMetadata();
            dbstruct.DataSource.LoadSubNodes();
            dbstruct.Nodes = dbstruct.DataSource.Nodes;
            dbstruct.DataSource.LoadRelationships();
            dbstruct.Relationships = dbstruct.DataSource.Relationships;
        }

        public override string ToString()
        {
            return String.Format("SQL Server {0} - {1}", connBuilder.DataSource, serverStructure != null ? String.Format("{0} Databases", serverStructure.Databases.Count):"Uninitialized");
        }
    }
}
