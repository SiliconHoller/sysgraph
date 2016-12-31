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

        private static string FK_QUERY = "SELECT "+
                                        "    o1.name AS FK_table,"+
                                        "    c1.name AS FK_column,"+
                                        "    fk.name AS FK_name,"+
                                        "    o2.name AS PK_table,"+
                                        "    c2.name AS PK_column,"+
                                        "    pk.name AS PK_name,"+
                                        "    fk.delete_referential_action_desc AS Delete_Action,"+
                                        "    fk.update_referential_action_desc AS Update_Action "+
                                        "FROM sys.objects o1 "+
                                        "    INNER JOIN sys.foreign_keys fk "+
                                        "        ON o1.object_id = fk.parent_object_id "+
                                        "    INNER JOIN sys.foreign_key_columns fkc "+
                                        "        ON fk.object_id = fkc.constraint_object_id "+
                                        "    INNER JOIN sys.columns c1 "+
                                        "        ON fkc.parent_object_id = c1.object_id "+
                                        "        AND fkc.parent_column_id = c1.column_id "+
                                        "    INNER JOIN sys.columns c2 "+
                                        "        ON fkc.referenced_object_id = c2.object_id "+
                                        "        AND fkc.referenced_column_id = c2.column_id "+
                                        "    INNER JOIN sys.objects o2 "+
                                        "        ON fk.referenced_object_id = o2.object_id "+
                                        "    INNER JOIN sys.key_constraints pk "+
                                        "        ON fk.referenced_object_id = pk.parent_object_id "+
                                        "        AND fk.key_index_id = pk.unique_index_id " +
                                        "ORDER BY o1.name, o2.name, fkc.constraint_column_id";

        protected List<SqlServerTableNode> tableList;
        protected List<SqlServerViewNode> viewList;
        protected List<SqlServerProcedureNode> procList;
        protected List<SqlServerFunctionNode> funcList;

        public SqlServerDatabaseNode(string dbname, SqlConnectionStringBuilder cbuilder)
            : base(dbname, cbuilder)
        {

        }

        protected override void LoadDatabaseObjects()
        {

            tableList = LoadTables();
            Nodes.AddRange(tableList);

            viewList = LoadViews();
            Nodes.AddRange(viewList);

            procList = LoadProcedures();
            Nodes.AddRange(procList);

            funcList = LoadFunctions();
            Nodes.AddRange(funcList);
        }

        protected override void LoadDatabaseRelationships()
        {
            if (Relationships == null) Relationships = new List<DataConnection>();
            Relationships.Clear();

            DataTable fkdatatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(FK_QUERY,conn))
                {
                    sda.Fill(fkdatatable);
                }
                conn.Close();
            }
            //start parsing through the data rows
            string pktable;
            string pkcolumn;
            string fktable;
            string fkcolumn;
            foreach (DataRow fkrow in fkdatatable.Rows)
            {
                pktable = fkrow["PK_table"].ToString();
                pkcolumn = fkrow["PK_column"].ToString();
                fktable = fkrow["FK_table"].ToString();
                fkcolumn = fkrow["FK_column"].ToString();

                SqlServerTableNode pknode = tableList.Where(t => t.TableName == pktable).SingleOrDefault();
                SqlServerTableNode fknode = tableList.Where(t => t.TableName == fktable).SingleOrDefault();
                if (pknode != null && fknode != null)
                {
                    DataConnection fkrel = new DataConnection 
                                                { 
                                                    ConnectionType = RecordKeys.ForeignKey, 
                                                    StartNode = pknode, 
                                                    EndNode = fknode,
                                                    Name = String.Format("{0}.{1}.{2} => {3}.{4}.{5}", pknode.Schema, pknode.TableName, pkcolumn, fknode.Schema, fknode.TableName, fkcolumn),
                                                    Description = String.Format("{0}: On Update = {1}, On Delete = {2}",fkrow["FK_name"].ToString(), fkrow["Update_Action"],fkrow["Delete_Action"].ToString())
                                                };
                    Relationships.Add(fkrel);

                }
            }
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
                    SqlServerTableNode tnode = new SqlServerTableNode(trow["TABLE_NAME"].ToString(), ConnectionStringBuilder);
                    tnode.Schema = trow["TABLE_SCHEMA"].ToString();
                    tnode.TableName = trow["TABLE_NAME"].ToString();
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
