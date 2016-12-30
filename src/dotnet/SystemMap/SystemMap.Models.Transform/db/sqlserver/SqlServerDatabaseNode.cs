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
    public class SqlServerDatabaseNode : DataSourceNodeBase
    {

        public SqlServerDatabaseNode(string dbname, SqlConnectionStringBuilder cbuilder)
            : base(dbname, cbuilder)
        {

        }

        protected override void LoadDatabaseObjects()
        {
            List<SqlServerTableNode> tlist = LoadTables();


            Nodes.AddRange(tlist);
        }

        protected override void LoadDatabaseRelationships()
        {
            
        }

        protected override void LoadDatabaseAttributes()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                DataTable dbtables = conn.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                foreach (DataRow dbrow in dbtables.Rows)
                {
                    if (dbrow[0].Equals(this.Name))
                    {
                        NodeAttribute idatt = new NodeAttribute { name = dbrow[1].ToString(), description = "Database Id", type = new AttributeType { name = EnumParser.GetValueName(DbClasses.Identifier) } };
                        NodeAttribute createdatt = new NodeAttribute { name = dbrow[2].ToString(), description = "Created Date", type = new AttributeType { name = EnumParser.GetValueName(DbColumnAttributes.DbDateTime) } };
                        Metadata.Add(idatt);
                        Metadata.Add(createdatt);
                        break;
                    }
                }
            }
        }

        protected List<SqlServerTableNode> LoadTables()
        {
            List<SqlServerTableNode> tlist = new List<SqlServerTableNode>();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                DataTable tables = conn.GetSchema(SqlClientMetaDataCollectionNames.Tables, new string[] { null, null, null, "BASE TABLE" });
                foreach (DataRow trow in tables.Rows)
                {
                    SqlServerTableNode tnode = new SqlServerTableNode(trow["TABLE_SCHEMA"].ToString(), trow["TABLE_NAME"].ToString(), ConnectionStringBuilder);
                    tlist.Add(tnode);
                }
                conn.Close();

            }
            return tlist;
        }

        protected List<SqlServerViewNode> LoadViews()
        {
            List<SqlServerViewNode> vlist = new List<SqlServerViewNode>();
            return vlist;
        }

        protected List<SqlServerProcedureNode> LoadProcedures()
        {
            List<SqlServerProcedureNode> plist = new List<SqlServerProcedureNode>();
            return plist;
        }

        protected List<SqlServerFunctionNode> LoadFunctions()
        {
            List<SqlServerFunctionNode> flist = new List<SqlServerFunctionNode>();
            return flist;

        }
    }
}
