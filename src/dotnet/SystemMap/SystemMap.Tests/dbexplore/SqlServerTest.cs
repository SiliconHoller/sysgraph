using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemMap.Entities.data;
using SystemMap.Models.Transform.db;
using SystemMap.Models.Transform.db.utils;

namespace SystemMap.Tests.dbexplore
{
    [TestClass]
    public class SqlServerTest
    {
        [TestMethod]
        public void AutoExploreTest()
        {
            SystemMapEntities smdb = new SystemMapEntities();
            string dbstring = smdb.Database.Connection.ConnectionString;
            SqlConnectionStringBuilder cbuilder = new SqlConnectionStringBuilder(dbstring);
            DbInspector sqlInspector = DbInspector.GetInstance(cbuilder);
            DataServerStructure serverData = sqlInspector.InitStructure();
            sqlInspector.LoadData();
            Assert.IsTrue(serverData.Databases.Count > 0);

            foreach (DataSourceStructure dbstruct in serverData.Databases)
            {
                if (dbstruct.DataSource.Name.Equals("SystemMap"))
                {
                    sqlInspector.LoadDataSource(dbstruct);
                    Assert.IsTrue(dbstruct.Nodes.Count > 0);
                    Assert.IsTrue(dbstruct.Relationships.Count > 0);
                }
            }
            
        }
    }
}
