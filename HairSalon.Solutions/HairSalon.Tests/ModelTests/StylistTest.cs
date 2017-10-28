using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests
    {

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=joseph_tomlinson_test;";
            Stylist.ClearAll();
            Client.ClearAll();
        }

        [TestMethod]
        public void Save_AddStylistTooDatabase_1()
        {
            Stylist testStylist = new Stylist("HasNoClients");
            testStylist.Save();
            int count = 0;
            Query databaseCount = new Query("SELECT * FROM stylists");
            var rdr = databaseCount.Read();
            while (rdr.Read())
            {
                count++;
            }
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void AssignClient_CreateClientAndRelateToStylist_1()
        {
            Stylist testStylist = new Stylist("Has1Client");
            testStylist.Save();

            Client newClient = new Client("Jimmy", "555-555-5555", "1234 NW Place Street", "Likes to keep it short.");
            testStylist.AssignClient(newClient);

            int count = 0;
            Query databaseCount = new Query("SELECT * FROM CLIENTS where stylist_id = @StylistId");
            databaseCount.AddParameter("@StylistId", testStylist.GetId().ToString());

            var rdr = databaseCount.Read();
            while (rdr.Read())
            {
                count++;
            }
            Assert.AreEqual(1, count);
        }
    }
}
