using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AimBridge.WebAPIRepository;
using AimBridge.WebAPIClient;


namespace AimBridge.WebAPI.UI
{
    public partial class setapikey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                lblMessage.Text = "";
                WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
                txtApiKey.Text = rep.APIKEY;
                txtBaseURL.Text = rep.baseurl;
                txtSource.Text = rep.ABsource;
            }
        }


        protected void btUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ConfigDbContext db = new ConfigDbContext();
            bool result = db.UpdateAPiKey(txtApiKey.Text,txtBaseURL.Text, txtSource.Text);

            if (result)
            {
                lblMessage.Text = "Config Value Updated.";
            }
            else
            {
                lblMessage.Text = "Some error occured. Please contact the Administrator.";
            }
        }
    }
    }