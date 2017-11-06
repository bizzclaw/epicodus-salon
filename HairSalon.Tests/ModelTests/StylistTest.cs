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
            DB.DatabaseTest();
            Stylist.ClearAll();
            Client.ClearAll();
        }

        [TestMethod]
        public void SaveAndGetAll_AddStylistTooDatabase_1()
        {
            Stylist testStylist = new Stylist("HasNoClients");
            testStylist.Save();

            List<Stylist> allStylists = Stylist.GetAll();
            Assert.AreEqual(1, allStylists.Count);
        }

        [TestMethod]
        public void AssignClientAndGetClients_CreateClientAndRelateToStylist_1()
        {
            Stylist testStylist = new Stylist("Has1Client");
            testStylist.Save();

            Client newClient = new Client("Jimmy", "555-555-5555", "1234 NW Place Street", "Likes to keep it short.");
            testStylist.AssignClient(newClient);
            List<Client> allClients = testStylist.GetClients();
            Assert.AreEqual(1, allClients.Count);
        }

        [TestMethod]
        public void Find_FindClientInDataBase_true()
        {
            Stylist testStylist = new Stylist("Man");
            testStylist.Save();
            Stylist findStylist = Stylist.Find(testStylist.GetId());
            Assert.AreEqual(testStylist.GetName(), findStylist.GetName());
        }
        [TestMethod]
        public void ClearAll_ClearAllStylists_0()
        {
            Stylist testStylist = new Stylist("Man");
            testStylist.Save();

            Stylist.ClearAll();

            List<Stylist> allStylists = Stylist.GetAll();
            Assert.AreEqual(0, allStylists.Count);
        }
    }
}
