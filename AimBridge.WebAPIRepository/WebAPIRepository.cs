using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AimBridge.WebAPIRepository;
using Newtonsoft.Json;
using System.Security.Authentication;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AimBridge.WebAPIClient
{
    public class WebAPIRepository
    {
        // added to bypass security exception
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
        //variables to be assigned from config file
        public readonly string APIKEY, baseurl,ABsource;
       
        public WebAPIRepository()
        {
            // added to bypass security exception
            ServicePointManager.SecurityProtocol = Tls12;
            List<ConfigModel> modelList = null;
            ConfigDbContext db = new ConfigDbContext();
            modelList = db.GetAllConfigValues();
            APIKEY = modelList.Where(x => x.ConfigKey == "apikey").Select(y => y.ConfigValue).ToList()[0];

               baseurl = modelList.Where(x => x.ConfigKey == "baseurl").Select(y => y.ConfigValue).ToList()[0];
            ABsource = modelList.Where(x => x.ConfigKey == "absource").Select(y => y.ConfigValue).ToList()[0];
        }

        public List<string> PostCompleteCourseRequest(string xmlstring)
        {
            List<string> results = new List<string>();
            string aburl = $"{baseurl}historyimports?source={ABsource}";
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(aburl);
            request.Headers.Add("apikey", APIKEY);
            byte[] requestInFormOfBytes = System.Text.Encoding.ASCII.GetBytes(xmlstring);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = requestInFormOfBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestInFormOfBytes, 0, requestInFormOfBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
            results.Add(respStream.ReadToEnd());           
            respStream.Close();
            response.Close();

            return results;
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

        public List<TeamUsersModel> GetTeamUsers(string teamid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            List<TeamUsersModel> TUmodels = null;
            client.Headers.Add("apikey", APIKEY);
            try
            {
                string content = client.DownloadString($"{baseurl}/teams/{teamid}/users?source={ABsource}?&format=json");

                TUmodels = JsonConvert.DeserializeObject<List<TeamUsersModel>>(content);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
            return TUmodels;

        }

        public string GetCourseCusatomImportBulkID(string courseid)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("apikey", APIKEY);
            


            try
            {
                string content = client.DownloadString($"{baseurl}/courses/{courseid}?source={ABsource}&format=json");
                JObject o = JObject.Parse(content);
                JToken t = o.SelectToken("CourseCodeForBulkImport");
                return t.ToString();
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
