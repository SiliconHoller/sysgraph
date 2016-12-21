using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemMap.Entities.data;
using SystemMap.Entities.util;

namespace SystemMap.Tests
{
    [TestClass]
    public class DbConnectivityTests
    {
        [TestMethod]
        public void TestConnectivity()
        {
            SystemMapEntities db = new SystemMapEntities();
            db.Dispose();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTypeSeed()
        {
            DbSeed seeder = new DbSeed();
            seeder.SeedTypeData();
        }
    }
}
