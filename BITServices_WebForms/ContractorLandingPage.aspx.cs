using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITServices_WebForms.DAL;
using BITServices_WebForms.Models;

namespace BITServices_WebForms
{
    public partial class ContractorLandingPage : System.Web.UI.Page
    {
        string[] userValues;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserValues"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            userValues = (string[])Session["UserValues"];

            if (!IsPostBack)
            {
                FillAvaliableJobRequests();
                FillActiveJobRequests();
                FillAllJobRequests();
            }
        }

        private void FillAvaliableJobRequests()
        {
            DataTable dt = JobSQLHelper.GetJobsForAcceptance(int.Parse(userValues[0]));

            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvAvaliableJobRequests.DataSource = dt;
            gvAvaliableJobRequests.DataBind();
        }

        private void FillActiveJobRequests()
        {
            DataTable dt = JobSQLHelper.GetJobsForCompletion(int.Parse(userValues[0]));

            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvActiveJobRequests.DataSource = dt;
            gvActiveJobRequests.DataBind();
        }

        private void FillAllJobRequests()
        {
            DataTable dt = ContractorSQLHelper.GetAllContractorJobs(int.Parse(userValues[0]));

            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvAllJobRequests.DataSource = dt;
            gvAllJobRequests.DataBind();
        }

        protected void gvAvaliableJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Accept")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvaliableJobRequests.Rows[rowIndex];

                DateTime date = DateTime.Parse(row.Cells[2].Text);
                string startTime = row.Cells[3].Text;
                string clientID = row.Cells[1].Text;

                if (JobSQLHelper.AcceptJob(date, startTime, clientID) == 1)
                {
                    Response.Write("<script>alert('Job Accepted');</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error has occured, please try again');</script>");
                }
            }

            if (e.CommandName == "Reject")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvaliableJobRequests.Rows[rowIndex];

                DateTime date = DateTime.Parse(row.Cells[2].Text);
                string startTime = row.Cells[3].Text;
                string clientID = row.Cells[1].Text;

                if (JobSQLHelper.RejectJob(date, startTime, clientID) == 1)
                {
                    Response.Write("<script>alert('Job Accepted');</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error has occured, please try again');</script>");
                }
            }

            FillActiveJobRequests();
            FillAvaliableJobRequests();
            FillAllJobRequests();
        }

        protected void gvActiveJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Mark Complete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvActiveJobRequests.Rows[rowIndex];

                txtDate.Value = row.Cells[1].Text;
                txtStartTime.Value = row.Cells[2].Text;
                txtSkill.Value = row.Cells[3].Text;
                txtDetails.Value = row.Cells[4].Text;
                txtStreet.Value = row.Cells[5].Text;
                txtSuburb.Value = row.Cells[6].Text;
                txtState.Value = row.Cells[7].Text;
                txtPostCode.Value = row.Cells[8].Text;
                txtClientID.Value = row.Cells[9].Text;
            }
        }

        protected void btnCompleteJob_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(txtDate.Value);
            string startTime = txtStartTime.Value;
            string clientID = txtClientID.Value;

            string endTime = txtJobEndTime.Value;
            string distanceTravelled = txtDistanceTravelled.Value;

            if (JobSQLHelper.CompleteJob(date, startTime, clientID, endTime, distanceTravelled) == 1)
            {
                Response.Write("<script>alert('Job Completed');</script>");
            }
            else
            {
                Response.Write("<script>alert('An error has occured, please try again');</script>");
            }

            FillActiveJobRequests();
            FillAvaliableJobRequests();
            FillAllJobRequests();
        }
    }
}