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
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
            string res = rep.GetUsers();
            Assert.IsTrue(res.Contains("<User"));
        }
        [TestMethod]
        public void TestGetTeam()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
            string teamnames = rep.GetTeamList();
            Assert.IsTrue(teamnames.Contains("<Team"));

        }
        [TestMethod]
        public void TestGetTeamCourses()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
            string teamcourses = rep.GetTeamCourses("RFzga2x9NxM1");

        }


        [TestMethod]
        public void TestGetCourseUsers()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
            string courseusers = rep.GetCourseUsers("rS1ivoKZBPQ1");
            Assert.IsTrue(courseusers.Contains("FirstName"));

        }
    }
}
