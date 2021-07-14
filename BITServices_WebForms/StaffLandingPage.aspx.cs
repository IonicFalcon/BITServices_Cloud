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
    public partial class StaffLandingPage : System.Web.UI.Page
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
            //Jobs for assignment
            DataTable dt = JobSQLHelper.GetJobsForAssignment();

            if (dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvAvaliableJobRequests.DataSource = dt;
            gvAvaliableJobRequests.DataBind();
        }

        private void FillActiveJobRequests()
        {
            //Jobs for assignment
            DataTable dt = JobSQLHelper.GetJobsForVerification();

            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvActiveJobRequests.DataSource = dt;
            gvActiveJobRequests.DataBind();
        }

        private void FillAllJobRequests()
        {
            //Jobs for verification
            DataTable dt = JobSQLHelper.GetAllJobs();

            if(dt.Rows.Count == 0)
            {
                dt = new DataTable();
            }

            gvAllJobRequests.DataSource = dt;
            gvAllJobRequests.DataBind();
        }

        protected void gvActiveJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Verify Job")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvActiveJobRequests.Rows[rowIndex];

                txtVerifyClientID.Value = row.Cells[5].Text;
                txtVerifyJobDate.Value = row.Cells[2].Text;
                txtVerifyJobStartTime.Value = row.Cells[3].Text;

            }
        }

        protected void gvAvaliableJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Assign")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvaliableJobRequests.Rows[rowIndex];

                txtStatus.Value = row.Cells[1].Text;
                txtDate.Value = row.Cells[2].Text;
                txtStartTime.Value = row.Cells[3].Text;
                txtClient.Value = row.Cells[4].Text;
                txtStreet.Value = row.Cells[5].Text;
                txtSuburb.Value = row.Cells[6].Text;
                txtState.Value = row.Cells[7].Text;
                txtPostCode.Value = row.Cells[8].Text;
                txtUrgency.Value = row.Cells[9].Text;
                txtSkill.Value = row.Cells[10].Text;
                txtProblem.Value = row.Cells[11].Text;

                string skillName = row.Cells[10].Text;
                string state = row.Cells[7].Text;
                

                gvAssignContractors.DataSource = ContractorSQLHelper.GetAssignableContractors(skillName, state);
                gvAssignContractors.DataBind();
            }
        }

        protected void btnAssignContractor_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAssignContractors.Rows)
            {
                RadioButton radio = row.FindControl("radSelected") as RadioButton;
                if (radio.Checked)
                {
                    DateTime date = DateTime.Parse(txtDate.Value);
                    string startTime = txtStartTime.Value;
                    string clientID = txtClient.Value;
                    string contractorID = row.Cells[1].Text;
                    if(JobSQLHelper.AssignJob(date, startTime, clientID, contractorID, userValues[0]) == 1)
                    {
                        Response.Write("<script>alert('Contractor Assigned to Job');</script>");
                        break;
                    }
                    else
                    {
                        Response.Write("<script>alert('An error has occured, please try again');</script>");
                        break;
                    }
                }
            }

            FillActiveJobRequests();
            FillAvaliableJobRequests();
            FillAllJobRequests();
        }

        protected void btnVerifyJob_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(txtVerifyJobDate.Value);
            string startTime = txtVerifyJobStartTime.Value;
            string clientID = txtVerifyClientID.Value;

            if(JobSQLHelper.VerifyJob(date, startTime, clientID) == 1)
            {
                Response.Write("<script>alert('Job Successfully Sent Out for Payment");
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