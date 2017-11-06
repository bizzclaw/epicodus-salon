using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests
    {

        public ClientTests()
        {
            DB.DatabaseTest();
            Client.ClearAll();
        }

        [TestMethod]
        public void SaveAndGetAll_AddClientTooDatabase_1()
        {
            Client testClient = new Client("Man", "Phone", "Place", "Notes");
            testClient.Save(0);

            List<Client> allClients = Client.GetAll();
            Assert.AreEqual(1, allClients.Count);
        }

        [TestMethod]
        public void ClearAll_ClearAllClients_0()
        {
            Client testClient = new Client("Man", "Phone", "Place", "Notes");
            testClient.Save(0);

            Client.ClearAll();

            List<Client> allClients = Client.GetAll();
            Assert.AreEqual(0, allClients.Count);
        }

    }
}
