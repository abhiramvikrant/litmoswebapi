using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AimBridge.WebAPIRepository;
using AimBridge.WebAPIClient;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;

namespace AimBridge.WebAPI.UI
{
    public partial class CourseComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                btComplete.Style.Add("display", "none");
                WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
                List<TeamModel> tmodels = rep.GetTeamList();
                if (tmodels != null)
                {
                    ddlTeam.DataSource = tmodels;
                    ddlTeam.DataBind();
                   
                }
            }
        }

        protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            if (ddlTeam.SelectedIndex > 0)
            {
                WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
                List<CourseModel> cmodel = rep.GetTeamCourses(ddlTeam.SelectedValue);
                if(cmodel!= null && cmodel.Count > 0)
                {
                    ddlCourse.DataSource = cmodel.Where(c => c.Active == true);
                    ddlCourse.DataBind();
                }
                else
                {
                    GetCourseByTeamID();
                }
            }
            else
            {
                GetCourseByTeamID();
            }
        }

        private void GetCourseByTeamID()
        {
            ddlCourse.Items.Clear();
            ddlCourse.Items.Insert(0, " -- Select --");
            ddlCourse.DataBind();
            gvUsers.DataSource = null;
            gvUsers.Style.Add("display", "none");
            
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {     
            BindGrid();
        }

        private void BindGrid()
        {
            List<UserModel> cmodel = null;
            List<TeamUsersModel> modelTu = null;
            if (ddlTeam.SelectedIndex > 0 && ddlCourse.SelectedIndex > 0)
            {
                WebAPIClient.WebAPIRepository rep = new WebAPIClient.WebAPIRepository();
                modelTu = rep.GetTeamUsers(ddlTeam.SelectedValue);
                cmodel = rep.GetCourseUsers(ddlCourse.SelectedValue).Where(x => x.Completed == false).ToList();
                var dsmodel = cmodel.Join(modelTu, r => r.UserName, y => y.Username, (r, y) => new { r.UserName, r.FirstName, r.LastName }).ToList();
                if (dsmodel.Count > 0)
                {
                    //gvUsers.Style.Add("display", "block");
                    gvUsers.DataSource = dsmodel;
                    gvUsers.DataBind();
                    btComplete.Style.Add("display", "block");
                }

            }
        }

        protected void btComplete_Click(object sender, EventArgs e)
        {
            GridViewRowCollection rows = gvUsers.Rows;
            StringBuilder xmlstr = new StringBuilder();
            string compdate = DateTime.Parse(datepicker.Value).ToString("yyyy-MM-dd");
            foreach (GridViewRow item in rows)
            {
                if(item.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("cbUsers");
                    if (chkSelect != null && chkSelect.Checked)
                    {
                        xmlstr.Append("<CourseHistoryImport>");
                        xmlstr.Append($"<Username>{item.Cells[1].Text}</Username>");
                        xmlstr.Append($"<CourseId></CourseId>");
                        xmlstr.Append($"<CompletedDate>{compdate}</CompletedDate>");
                        xmlstr.Append($"<Complete>true</Complete>");
                        xmlstr.Append("</CourseHistoryImport>");
                        xmlstr.Replace("<", "&lt;").Replace(">", "&gt;").Replace(@"\", "\\");
                        lblmsg.Text = xmlstr.ToString();
                        //XElement root = new XElement("CourseHistoryImport", 
                        //    new XElement("Username", item.Cells[1].Text),
                        //    new XElement("CourseId", string.Empty),
                        //    new XElement("CompletedDate", compdate),
                        //    new XElement("Complete", "true"));
                        //lblmsg.Text = root.ToString();


                    }

                }

            }

           
        }
    }
}