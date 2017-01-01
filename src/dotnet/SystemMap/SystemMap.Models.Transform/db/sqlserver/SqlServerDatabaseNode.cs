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
        /// <summary>
        /// Query from http://dba.stackexchange.com/questions/31720/how-to-find-the-foreign-key-associated-with-a-given-primary-key/31721#31721?newreg=79004bda036f4974ba1b914433b7f21c
        /// </summary>
        public const string FK_QUERY = "SELECT "+
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

        /// <summary>
        /// Query based on https://msdn.microsoft.com/en-us/library/ms190624.aspx
        /// </summary>
        public const string DEPENDENCY_QUERY = "SELECT DISTINCT OBJECT_NAME(referencing_id) AS referencing_entity_name,   " +
                                           "     o.type_desc AS referencing_desciption,    " +
                                            "    COALESCE(COL_NAME(referencing_id, referencing_minor_id), '(n/a)') AS referencing_minor_id,    " +
                                            "    referencing_class_desc, referenced_class_desc,   " +
                                            "    referenced_server_name, referenced_database_name, referenced_schema_name,   " +
                                            "    referenced_entity_name,    " +
                                            //"    COALESCE(COL_NAME(referenced_id, referenced_minor_id), '(n/a)') AS referenced_column_name,   " +
                                            "    is_caller_dependent, is_ambiguous   " +
                                            "FROM sys.sql_expression_dependencies AS sed   " +
                                            "INNER JOIN sys.objects AS o ON sed.referencing_id = o.object_id;";

        /// <summary>
        /// Query based on https://msdn.microsoft.com/en-us/library/ms345404.aspx#TsqlProcedure
        /// </summary>
        public const string SPECIFIC_DEPENDENCY_QUERY = "SELECT DISTINCT OBJECT_NAME(referencing_id) AS referencing_entity_name,    " +
                                                        "        o.type_desc AS referencing_desciption,    " +
                                                        "        COALESCE(COL_NAME(referencing_id, referencing_minor_id), '(n/a)') AS referencing_minor_id,    " +
                                                        "        referencing_class_desc, referenced_class_desc,   " +
                                                        "        referenced_server_name, referenced_database_name, referenced_schema_name,   " +
                                                        "        referenced_entity_name,    " +
                                                        //"        COALESCE(COL_NAME(referenced_id, referenced_minor_id), '(n/a)') AS referenced_column_name,   " +
                                                        "        is_caller_dependent, is_ambiguous   " +
                                                        "    FROM sys.sql_expression_dependencies AS sed   " +
                                                        "    INNER JOIN sys.objects AS o ON sed.referencing_id = o.object_id " +
                                                        "    WHERE referencing_id = OBJECT_ID(@depName);";  

        
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

            //Foreign key relationships
            LoadTableRelationships();
            //View, procedure, and function relationships
            DataTable refdatatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(DEPENDENCY_QUERY, conn))
                {
                    sda.Fill(refdatatable);
                }
                conn.Close();
            }
            //start parsing through the data rows
            string referencing;
            string referenced;
            foreach (DataRow refrow in refdatatable.Rows)
            {
                referencing = refrow["referencing_entity_name"].ToString();
                referenced = refrow["referenced_entity_name"].ToString();
                DataSourceNodeBase referrer = Nodes.Where(n => n.ObjectName == referencing).FirstOrDefault();
                if (referrer != null)
                {
                    //We have a start node
                    DataConnection depconn = new DataConnection
                    {
                        ConnectionType = RecordKeys.Dependency,
                        StartNode = null,
                        EndNode = referrer
                    };
                    if (refrow["referenced_server_name"] == null && refrow["referenced_database_name"] == null)
                    {
                        //Dealing with an internal reference
                        depconn.StartNode = Nodes.Where(n => n.ObjectName == referenced).FirstOrDefault();
                    }
                    else
                    {
                        //Dealing with an external reference
                        string refserver = refrow["referenced_server_name"] != null ? refrow["referenced_server_name"].ToString() : null;
                        string refdb = refrow["referenced_database_name"] != null ? refrow["referenced_database_name"].ToString() : null;
                        string refschema = refrow["referenced_schema_name"] != null ? refrow["referenced_schema_name"].ToString() : null;
                        string refobj = refrow["referenced_entity_name"].ToString();
                        List<string> ancestry = new List<string>();
                        if (!String.IsNullOrEmpty(refserver) && !String.IsNullOrWhiteSpace(refserver))
                        {
                            //See if such a node exists--if not, create one
                            DataSourceNodeBase servernode = Nodes.Where(n => n.Name == refserver).FirstOrDefault();
                            if (servernode == null)
                            {
                                servernode = new GenericDataSourceNode(refserver, ConnectionStringBuilder);
                                servernode.ObjectName = refserver;
                                Nodes.Add(servernode);
                            }
                            ancestry.Add(refserver);
                            

                        }
                        if (!String.IsNullOrEmpty(refdb) && !String.IsNullOrWhiteSpace(refdb)) 
                        {
                            DataSourceNodeBase dbnode = Nodes.Where(n => n.Name == refdb).FirstOrDefault();
                            if (dbnode == null)
                            {
                                dbnode = new GenericDataSourceNode(refdb, ConnectionStringBuilder);
                                dbnode.ObjectName = refdb;
                                dbnode.Lineage = CreateNameSpace(ancestry);
                                Nodes.Add(dbnode);
                            }
                            ancestry.Add(refdb);
                        }
                        GenericDataSourceNode extrefnode = new GenericDataSourceNode(refobj, ConnectionStringBuilder);
                        extrefnode.Schema = refschema;
                        extrefnode.ObjectName = refobj;
                        if (ancestry.Count > 0) extrefnode.Lineage = CreateNameSpace(ancestry);
                        depconn.StartNode = extrefnode;
                    }
                    if (depconn.StartNode != null)
                    {
                        depconn.Name = String.Format("{0} => {1}", depconn.StartNode.ToString(), depconn.EndNode.ToString());
                        Relationships.Add(depconn);
                    }
                    
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
                    tnode.ObjectName = trow["TABLE_NAME"].ToString();
                    List<string> ancestry = new List<string>();
                    ancestry.Add(Name);
                    if (!String.IsNullOrEmpty(tnode.Schema)) ancestry.Add(tnode.Schema);
                    tnode.Lineage = CreateNameSpace(ancestry);
                    tlist.Add(tnode);
                }
                conn.Close();

            }
            return tlist;
        }

        protected List<SqlServerViewNode> LoadViews()
        {
            List<SqlServerViewNode> vlist = new List<SqlServerViewNode>();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                DataTable views = conn.GetSchema(SqlClientMetaDataCollectionNames.Views);
                foreach (DataRow vrow in views.Rows)
                {
                    SqlServerViewNode vnode = new SqlServerViewNode(vrow["TABLE_NAME"].ToString(), ConnectionStringBuilder);
                    vnode.Schema = vrow["TABLE_SCHEMA"].ToString();
                    vnode.ObjectName = vrow["TABLE_NAME"].ToString();
                    List<string> ancestry = new List<string>();
                    ancestry.Add(Name);
                    if (!String.IsNullOrEmpty(vnode.Schema)) ancestry.Add(vnode.Schema);
                    vnode.Lineage = CreateNameSpace(ancestry);
                    vlist.Add(vnode);
                }
                conn.Close();
            }
            return vlist;
        }

        protected List<SqlServerProcedureNode> LoadProcedures()
        {
            List<SqlServerProcedureNode> plist = new List<SqlServerProcedureNode>();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                DataTable procs = conn.GetSchema(SqlClientMetaDataCollectionNames.Procedures, new string[] { null, null, null, "PROCEDURE" });
                foreach (DataRow srow in procs.Rows)
                {
                    SqlServerProcedureNode pnode = new SqlServerProcedureNode(srow["SPECIFIC_NAME"].ToString(), ConnectionStringBuilder);
                    pnode.Schema = srow["SPECIFIC_SCHEMA"].ToString();
                    pnode.ObjectName = srow["SPECIFIC_NAME"].ToString();
                    List<string> ancestry = new List<string>();
                    ancestry.Add(Name);
                    if (!String.IsNullOrEmpty(pnode.Schema)) ancestry.Add(pnode.Schema);
                    pnode.Lineage = CreateNameSpace(ancestry);
                    plist.Add(pnode);
                }
            }
            return plist;
        }

        protected List<SqlServerFunctionNode> LoadFunctions()
        {
            List<SqlServerFunctionNode> flist = new List<SqlServerFunctionNode>();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                DataTable procs = conn.GetSchema(SqlClientMetaDataCollectionNames.Procedures, new string[] { null, null, null, "FUNCTION" });
                foreach (DataRow srow in procs.Rows)
                {
                    SqlServerFunctionNode fnode = new SqlServerFunctionNode(srow["SPECIFIC_NAME"].ToString(), ConnectionStringBuilder);
                    fnode.Schema = srow["SPECIFIC_SCHEMA"].ToString();
                    fnode.ObjectName = srow["SPECIFIC_NAME"].ToString();
                    List<string> ancestry = new List<string>();
                    ancestry.Add(Name);
                    if (!String.IsNullOrEmpty(fnode.Schema)) ancestry.Add(fnode.Schema);
                    fnode.Lineage = CreateNameSpace(ancestry);
                    flist.Add(fnode);
                }
            }
            return flist;
        }


        protected void LoadTableRelationships()
        {
            DataTable fkdatatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(FK_QUERY, conn))
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

                SqlServerTableNode pknode = tableList.Where(t => t.ObjectName == pktable).SingleOrDefault();
                SqlServerTableNode fknode = tableList.Where(t => t.ObjectName == fktable).SingleOrDefault();
                if (pknode != null && fknode != null)
                {
                    DataConnection fkrel = new DataConnection
                    {
                        ConnectionType = RecordKeys.ForeignKey,
                        StartNode = pknode,
                        EndNode = fknode,
                        Name = String.Format("{0}.{1}.{2} => {3}.{4}.{5}", pknode.Schema, pknode.ObjectName, pkcolumn, fknode.Schema, fknode.ObjectName, fkcolumn),
                        Description = String.Format("{0}: On Update = {1}, On Delete = {2}", fkrow["FK_name"].ToString(), fkrow["Update_Action"], fkrow["Delete_Action"].ToString())
                    };
                    Relationships.Add(fkrel);

                }
            }
        }

        protected NameSpace CreateNameSpace(IEnumerable<string> names)
        {
            NameSpace ns = new NameSpace();
            
            if (names != null)
            {
                List<Membership> plist = new List<Membership>();
                foreach (string cname in names)
                {
                    Membership ancestor = new Membership
                    {
                        containingNode = new Node { name = cname}
                    };
                    plist.Add(ancestor);
                }
                ns.containers = plist;
            }
            return ns;
        }
    }
}
