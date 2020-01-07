using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AimBridge.WebAPIRepository;
namespace AimBridge.UnitTests
{
    /// <summary>
    /// Summary description for ConfigUnitTest
    /// </summary>
    [TestClass]
    public class ConfigUnitTest
    {
        public ConfigUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetApiKey()
        {
            //
            // TODO: Add test logic here
            //

            ConfigDbContext db = new ConfigDbContext();
            string ret = db.GetAPIKey();
            Assert.IsTrue(ret.Length > 0);
        }

        [TestMethod]
        public void TestUpdateApiKey()
        {

            ConfigDbContext db = new ConfigDbContext();
            bool ret = db.UpdateAPiKey("e8ef19cd-cd95-4e61-b78f-d3a2d04fcc5a");
        Assert.IsTrue(ret);
        }

    }
}
