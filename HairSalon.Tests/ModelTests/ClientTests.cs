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
    }
}
