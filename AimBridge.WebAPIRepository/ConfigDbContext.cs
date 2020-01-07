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
        
        public string GetAPIKey()
        {
            string api = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abcon"].ToString());
            SqlCommand com = new SqlCommand("GetAPIKey", con);
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


        public bool UpdateAPiKey(string apikey)
        {
            bool retval = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abcon"].ConnectionString);
            SqlCommand com = new SqlCommand("UpdateAPIKey", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@apikey", apikey);
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
