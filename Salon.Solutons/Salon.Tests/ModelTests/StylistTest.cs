using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salon.Models;

namespace Salon.Tests
{
    [TestClass]
    public class StylistTests
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=joseph_tomlinson_test;";
            Client.ClearAll(); // instead of clearing clients in dispose, we clear them here for more consistent results, and so we can preview info between tests.
        }

        [TestMethod]
        public void RegisterClient_AddClientTooDatabase_1()
        {
            Client newClient = new Client("Jimmy", "555-555-5555", "1234 NW Place Street", "Likes to keep it short.");
            newClient.Save();
            int count = 0;
            Query databaseCount = new Query("SELECT * FROM clients");
            var rdr = databaseCount.Read();
            while (rdr.Read())
            {
                count++;
            }
            Assert.AreEqual(1, count);
        }
    }
}
