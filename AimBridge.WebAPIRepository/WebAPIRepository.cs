using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AimBridge.WebAPIRepository;
using Newtonsoft.Json;
using System.Security.Authentication;
using System.Net;

namespace AimBridge.WebAPIClient
{
    public class WebAPIRepository
    {
        // added to bypass security exception
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
        //variables to be assigned from config file
        private readonly string APIKEY, baseurl,ABsource;
       
        public WebAPIRepository()
        {
            // added to bypass security exception
            ServicePointManager.SecurityProtocol = Tls12;
               APIKEY= ConfigurationManager.AppSettings["ABapikey"].ToString();
               baseurl = ConfigurationManager.AppSettings["baseurl"].ToString();
            ABsource = ConfigurationManager.AppSettings["ABsource"].ToString();
        }

      
        public string GetUsers()
        {
            System.Net.WebClient client = new System.Net.WebClient();         
            client.Headers.Add("apikey", APIKEY);
            try
            {
                Uri weburl = new Uri($"{baseurl}users?source={ABsource}");
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

       
        
        public List<TeamModel> GetTeamList()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            List<TeamModel> tmodels = null;
            try
            {
      
                string content = client.DownloadString($"{baseurl}teams?source={ABsource}&format=json");
                tmodels = JsonConvert.DeserializeObject<List<TeamModel>>(content);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        finally
            {
                client.Dispose();
            }

            return tmodels;

        }

       
        public List<CourseModel> GetTeamCourses(string teamid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            List<CourseModel> cmodels = null;

            
            try
            {
                string content = client.DownloadString($"{baseurl}/teams/{teamid}/courses?source={ABsource}&format=json");
                cmodels = JsonConvert.DeserializeObject<List<CourseModel>>(content);
            }
            catch(Exception ex) { 
             throw new Exception(ex.Message);
        }
        finally
            {
                client.Dispose();
            }

            return cmodels;



}

        public List<UserModel> GetCourseUsers(string courseid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            List<UserModel> models = null;
            client.Headers.Add("apikey", APIKEY);
            try
            {
                string content = client.DownloadString($"{baseurl}/courses/{courseid}/users?source={ABsource}?&format=json");
         
                models = JsonConvert.DeserializeObject<List<UserModel>>(content);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
            return models;
        }
    }
}
