using Microsoft.VisualStudio.TestTools.UnitTesting;
using AimBridge.WebAPIClient;
using AimBridge.WebAPIRepository;
using System.Collections.Generic;

namespace AimBridge.UnitTests
{
    [TestClass]
    public class AimBridgeTests
    {
   
        [TestMethod]
        public void TestGetTeam()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
           List<TeamModel> tmod = rep.GetTeamList();
            Assert.IsTrue(tmod.Count> 0);

        }
        [TestMethod]
        public void TestGetTeamCourses()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
            List<CourseModel> teamcourses = rep.GetTeamCourses("RFzga2x9NxM1");
            Assert.IsInstanceOfType(teamcourses, typeof(List<CourseModel>));
            Assert.IsTrue(teamcourses.Count > 0);

        }


        [TestMethod]
        public void TestGetCourseUsers()
        {
            WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
System.Collections.Generic.List<UserModel> courseusers = rep.GetCourseUsers("rS1ivoKZBPQ1");
            Assert.IsTrue(courseusers.Count> 0);

        }
    }
}
