using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Enums;
using SystemMap.Models.Transform.util;

namespace SystemMap.Models.Transform.db.sqlserver
{
    public class SqlServerInstanceNode : DataSourceNodeBase
    {
        public SqlServerInstanceNode(string serverName, SqlConnectionStringBuilder connBuilder)
            : base(serverName, connBuilder)
        {

        }

        protected override void LoadDatabaseObjects()
        {
            Nodes.Clear();
            //list the databases
            SqlConnectionStringBuilder dbconnbuilder = new SqlConnectionStringBuilder();
            dbconnbuilder.DataSource = ConnectionStringBuilder.DataSource;
            dbconnbuilder.IntegratedSecurity = ConnectionStringBuilder.IntegratedSecurity;
            dbconnbuilder.UserID = ConnectionStringBuilder.UserID;
            dbconnbuilder.Password = ConnectionStringBuilder.Password;
            using (SqlConnection dbinstance = new SqlConnection(dbconnbuilder.ConnectionString))
            {
                dbinstance.Open();
                DataTable databases = dbinstance.GetSchema();
                foreach (DataRow dbrow in databases.Rows)
                {
                    SqlConnectionStringBuilder dbconn = new SqlConnectionStringBuilder(dbinstance.ConnectionString);
                    dbconn.InitialCatalog = dbrow[0].ToString();
                    SqlServerDatabaseNode dbnode = new SqlServerDatabaseNode(dbconn.InitialCatalog, dbconn);

                }
            }
        }

        protected override void LoadDatabaseRelationships()
        {
            //do nothing for this level
        }

        protected override void LoadDatabaseAttributes()
        {
            if (Metadata == null) Metadata = new List<NodeAttribute>();
            Metadata.Clear();
            NodeAttribute typenode = new NodeAttribute
                                        {
                                            name = ConnectionStringBuilder.DataSource,
                                            description = "SQL Server Instance",
                                            type = new AttributeType
                                            {
                                                name = EnumParser.GetValueName(ItActorTypes.Service)
                                            }
                                        };
            Metadata.Add(typenode);
        }
    }
}
