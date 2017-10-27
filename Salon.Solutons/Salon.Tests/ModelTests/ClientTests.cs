using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salon.Models;

namespace Salon.Tests
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
