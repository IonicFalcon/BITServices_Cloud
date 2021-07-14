using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITServices_WebForms.DAL;
using BITServices_WebForms.Models;

namespace BITServices_WebForms
{
    public partial class ClientLandingPage : System.Web.UI.Page
    {
        string[] userValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserValues"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            userValues = (string[])Session["UserValues"];

            if (!Page.IsPostBack)
            {
                FillActiveJobRequests();
                FillAllJobRequests();

                ddlSkill.DataSource = SQLHelper.GetAllSkills();
                ddlSkill.DataBind();
            }
        }

        private void FillActiveJobRequests()
        {
            DataTable dt = ClientSQLHelper.GetActiveClientJobs(int.Parse(userValues[0]));
            
            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvActiveJobRequests.DataSource = dt;
            gvActiveJobRequests.DataBind();
        }

        private void FillAllJobRequests()
        {
            DataTable dt = ClientSQLHelper.GetAllClientJobs(int.Parse(userValues[0]));

            if (dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvAllJobs.DataSource = dt;
            gvAllJobs.DataBind();
        }

        protected void btnCreateJob_Click(object sender, EventArgs e)
        {
            Job newJob = new Job();
            Client client = ClientSQLHelper.GetClientFromID(int.Parse(userValues[0]));

            newJob.StartDateTime = DateTime.ParseExact(dateJob.Value + " " + timeJob.Value, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            newJob.JobClient = client;
            newJob.SkillType = ddlSkill.SelectedValue;
            newJob.Urgency = ddlUrgency.Value;
            newJob.Street = txtStreet.Value;
            newJob.Suburb = txtSuburb.Value;
            newJob.State = ddlState.Value;
            newJob.PostCode = txtPostCode.Value;
            newJob.JobDetails = txtJobProblem.Value;

            if(JobSQLHelper.CreateJob(newJob) == 0)
            {
                Response.Write("<script>alert('An error has occured, please try again');</script>");
            }

            FillActiveJobRequests();
            FillAllJobRequests();
        }

        protected void btnCancelJob_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvActiveJobRequests.Rows)
            {
                CheckBox check = row.FindControl("chkSelected") as CheckBox;
                if (check.Checked)
                {
                    DateTime date = DateTime.Parse(row.Cells[1].Text);
                    string startTime = row.Cells[2].Text;

                    if(JobSQLHelper.DeleteJob(date, startTime, userValues[0]) == 0)
                    {
                        Response.Write("<script>alert('An error has occured, please try again');</script>");
                        break;
                    }
                }
            }

            FillActiveJobRequests();
            FillAllJobRequests();
        }

    }
}