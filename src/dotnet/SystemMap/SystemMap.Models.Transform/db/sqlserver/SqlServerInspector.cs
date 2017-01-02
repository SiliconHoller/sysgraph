using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.service;
using SystemMap.Enums;
using SystemMap.Models.Transform.db.utils;
using SystemMap.Models.Transform.util;

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
        
        public override void PersistMap(DataSourceStructure dbstruct)
        {
            //translate the structure into the SystemMap Services.
            StoreServerNode();
            SqlServerDatabaseNode databaseNode = (SqlServerDatabaseNode)dbstruct.DataSource;
            StoreDbNode(databaseNode);
            dbstruct.Nodes.Add(serverStructure.ServerNode);
            dbstruct.Nodes.Add(dbstruct.DataSource);
            StoreNodes(dbstruct.Nodes, databaseNode);
            StoreDependencies(dbstruct.Relationships);
        }

        protected void StoreServerNode()
        {
            DataSourceNodeBase srvrNode = serverStructure.ServerNode;
            NodeService nsvc = new NodeService();
            TypeService tsvc = new TypeService();
            AttributeService attsvc = new AttributeService();
            Node existing = nsvc.GetByName(srvrNode.Name);
            if (existing == null)
            {
                //doesn't exist--add it
                existing = new Node { name = srvrNode.Name };
                NodeType srvrType = tsvc.GetNodeType("SQL Server",true);
                existing.type = srvrType;
                int srvrId = nsvc.AddNode(existing);
                existing.id = srvrId;
            }
            else
            {
                srvrNode.NodeIdentity = existing.id;
            }
            if (srvrNode.Metadata != null)
            {
                foreach (NodeAttribute natt in srvrNode.Metadata)
                {
                    try
                    {
                        AttributeType atype = tsvc.GetAttributeType(natt.type.name, true);
                        natt.nodeId = existing.id;
                        natt.type = atype;
                        attsvc.AddNodeAttribute(natt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }

        protected void StoreDbNode(SqlServerDatabaseNode dbnode)
        {
            TypeService tsvc = new TypeService();
            if (dbnode.NodeIdentity == 0)
            {

                NodeService nsvc = new NodeService();
                AttributeService attsvc = new AttributeService();

                NodeType dbtype = tsvc.GetNodeType("Database", true);

                Node existing = nsvc.GetByName(dbnode.Name);
                if (existing == null)
                {
                    existing = new Node
                    {
                        name = dbnode.Name,
                        description = "SQL Server Database",
                        type = dbtype
                    };
                    int dbnodeid = nsvc.AddNode(existing);
                    dbnode.NodeIdentity = dbnodeid;
                    if (dbnode.Metadata != null)
                    {
                        foreach (NodeAttribute natt in dbnode.Metadata)
                        {
                            AttributeType atype = tsvc.GetAttributeType(natt.type.name, true);
                            natt.nodeId = dbnodeid;
                            natt.type = atype;
                            attsvc.AddNodeAttribute(natt);
                        }
                    }
                }
                else
                {
                    dbnode.NodeIdentity = existing.id;
                }
            }
            //If the identities are set, add membership setting
            if (dbnode.NodeIdentity != 0 && serverStructure.ServerNode.NodeIdentity != 0)
            {
                MembershipType mtype = tsvc.GetMembershipType("Database", true);
                MembershipService msvc = new MembershipService();
                msvc.AddNodeMembership(serverStructure.ServerNode.NodeIdentity, dbnode.NodeIdentity, mtype.typeId);
            }
        }

        protected void StoreNodes(List<DataSourceNodeBase> nlist, SqlServerDatabaseNode databaseNode)
        {
            NodeService nsvc = new NodeService();
            TypeService tsvc = new TypeService();
            AttributeService attsvc = new AttributeService();
            MembershipService msvc = new MembershipService();
            foreach (DataSourceNodeBase dbnode in nlist)
            {
                string memtypename = null;
                    
                //if there is a non-zero id value, it's already been stored/pulled.
                if (dbnode.NodeIdentity == 0)
                {
                    Node existnode = nsvc.GetByName(dbnode.Name);
                    if (existnode == null)
                    {
                        //hasn't been added yet--create one
                        Type nclasstype = dbnode.GetType();
                        string ntypename = null;
                        switch (nclasstype.FullName)
                        {
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerInstanceNode":
                                ntypename = "SQL Server";
                                memtypename = null;
                                break;
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerDatabaseNode":
                                ntypename = EnumParser.GetValueName(DbClasses.Database);
                                memtypename = null;
                                break;
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerTableNode":
                                ntypename = EnumParser.GetValueName(DbClasses.Table);
                                memtypename = ntypename;
                                break;
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerViewNode":
                                ntypename = EnumParser.GetValueName(DbClasses.View);
                                memtypename = ntypename;
                                break;
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerProcedureNode":
                                ntypename = EnumParser.GetValueName(DbProcesses.StoredProcedue);
                                memtypename = ntypename;
                                break;
                            case "SystemMap.Models.Transform.db.sqlserver.SqlServerFunctionNode":
                                ntypename = EnumParser.GetValueName(DbProcesses.Function);
                                memtypename = ntypename;
                                break;
                            case "SystemMap.Models.Transform.db.GenericDataSourceNode":
                                ntypename = "External Reference";
                                memtypename = null;
                                break;
                            default:
                                ntypename = "General";
                                memtypename = null;
                                break;

                        }
                        NodeType ntype = tsvc.GetNodeType(ntypename, true);
                        existnode = new Node
                                        {
                                            name = dbnode.Name,
                                            description = ntypename,
                                            type = ntype
                                        };
                        try
                        {
                            int nid = nsvc.AddNode(existnode);
                            dbnode.NodeIdentity = nid;
                            if (dbnode.Metadata != null)
                            {
                                foreach (NodeAttribute natt in dbnode.Metadata)
                                {
                                    try
                                    {
                                        AttributeType atype = tsvc.GetAttributeType(natt.type.name, true);
                                        natt.nodeId = dbnode.NodeIdentity;
                                        natt.type = atype;
                                        attsvc.AddNodeAttribute(natt);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.StackTrace);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                    else
                    {
                        dbnode.NodeIdentity = existnode.id;
                    }
                }
                if (memtypename != null) 
                {
                    MembershipType mtype = tsvc.GetMembershipType(memtypename, true);
                    if (mtype != null && databaseNode.NodeIdentity != 0 && dbnode.NodeIdentity != 0)
                    {
                        try
                        {
                            msvc.AddNodeMembership(databaseNode.NodeIdentity, dbnode.NodeIdentity, mtype.typeId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                }
            }
        }

        protected void StoreDependencies(List<DataConnection> dlist)
        {
            TypeService tsvc = new TypeService();
            EdgeService esvc = new EdgeService();
            foreach (DataConnection econn in dlist)
            {
                if (econn.EdgeId == 0) {
                    if (econn.StartNode != null && econn.EndNode != null)
                    {
                        DataSourceNodeBase u = econn.StartNode;
                        DataSourceNodeBase v = econn.EndNode;
                        if (u.NodeIdentity != 0 && v.NodeIdentity != 0)
                        {
                            string typename = EnumParser.GetValueName(econn.ConnectionType);
                            EdgeType etype = tsvc.GetEdgeType(typename, true);
                            //Create an edge to added
                            Edge addEdge = new Edge
                            {
                                name = econn.Name,
                                fromNodeId = u.NodeIdentity,
                                toNodeId = v.NodeIdentity,
                                description = econn.Description,
                                type = etype
                            };
                            try
                            {
                                int edgeid = esvc.AddEdge(addEdge);
                                econn.EdgeId = edgeid;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                            }
                        }
                    }
                }
            }
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
