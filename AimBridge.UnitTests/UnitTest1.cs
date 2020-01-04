using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AimBridge.WebAPIClient;

namespace AimBridge.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUsers()
        {
            WebAPIRepository rep = new WebAPIRepository();
            string res = rep.GetUsers();
            Assert.IsTrue(res.Contains("<User"));
        }
        [TestMethod]
        public void TestGetTeam()
        {
            WebAPIRepository rep = new WebAPIRepository();
            string teamnames = rep.GetTeamList();
            Assert.IsTrue(teamnames.Contains("<Team"));

        }
        [TestMethod]
        public void TestGetTeamCourses()
        {
            WebAPIRepository rep = new WebAPIRepository();
            string teamcourses = rep.GetTeamCourses("RFzga2x9NxM1");

        }


        [TestMethod]
        public void TestGetCourseUsers()
        {
            WebAPIRepository rep = new WebAPIRepository();
            string courseusers = rep.GetCourseUsers("rS1ivoKZBPQ1");

        }
    }
}
