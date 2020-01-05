using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AimBridge.WebAPIClient
{
    public class WebAPIRepository
    {

        private readonly string APIKEY = ConfigurationManager.AppSettings["ABapikey"].ToString();
        private readonly string baseurl = ConfigurationManager.AppSettings["baseurl"].ToString();
        public string GetUsers()
        {
            System.Net.WebClient client = new System.Net.WebClient();         
            client.Headers.Add("apikey", APIKEY);
            try
            {
                Uri weburl = new Uri($"{baseurl}users?source=abhiram");
                string content = client.DownloadString(weburl);
                return content;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                client.Dispose();
            }



        }

        public string GetTeamList()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            try
            {
                string content = client.DownloadString($"{baseurl}teams?source=abhiram");
                return content;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        finally
            {
                client.Dispose();
            }

        }

       
        public string GetTeamCourses(string teamid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            try
            {
                string content = client.DownloadString($"{baseurl}/teams/{teamid}/courses?source=abhiram");
                return content;
            }
            catch(Exception ex) { 
             throw new Exception(ex.Message);
        }
        finally
            {
                client.Dispose();
            }





}

        public string GetCourseUsers(string courseid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            try
            {
                string content = client.DownloadString($"{baseurl}/courses/{courseid}/users?source=abhiram?&format=json");
                return content;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
