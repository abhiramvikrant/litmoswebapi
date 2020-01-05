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
    public partial class CourseComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
                List<TeamModel> tmodels = rep.GetTeamList();
                if (tmodels != null)
                {
                    ddlTeam.DataSource = tmodels;
                    ddlTeam.DataBind();
                }
            }
        }
    }
}