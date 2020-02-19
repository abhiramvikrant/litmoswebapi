using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
 

namespace AimBridge.WebAPIRepository
{
   public class ConfigDbContext
    {
        public List<ConfigModel> GetAllConfigValues()
        {
            List<ConfigModel> model = new List<ConfigModel>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abcon"].ToString());
            SqlCommand com = new SqlCommand("GetAllConfigValues", con);

            com.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    model.Add(new ConfigModel { ConfigKey = reader.GetString(1), ConfigValue = reader.GetString(2) });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                com.Dispose();
            }
            return model;
            }
        
        public string GetConfigValue(string ConfigKey)
        {
            string api = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abcon"].ToString());
            SqlCommand com = new SqlCommand("GetAPIKey", con);
            com.Parameters.AddWithValue("@ConfigKey", ConfigKey);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                api = com.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                com.Dispose();
                con.Close();
            }

            return api;
        }


        public bool UpdateAPiKey(string apikey, string baseurl, string source)
        {
            bool retval = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abcon"].ConnectionString);
            SqlCommand com = new SqlCommand("UpdateAPIKey", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApiKey",apikey);
            com.Parameters.AddWithValue("@BaseUrl", baseurl);
            com.Parameters.AddWithValue("@Source", source);
            try
            {
                con.Open();
             int i   = com.ExecuteNonQuery();
                if (i > 0)
                    retval = true;
                else
                    retval = false;

            }
            catch (Exception ex)
            {
                retval = false;
                throw new Exception(ex.Message);              
            }
            finally
            {
                com.Dispose();
                con.Close();
            }

            return retval;
        }
    }
}
