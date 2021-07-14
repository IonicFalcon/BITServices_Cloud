using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITServices_WebForms.Models;
using BITServices_WebForms.DAL;

namespace BITServices_WebForms
{
    public partial class LoggedInMaster : System.Web.UI.MasterPage
    {
        Person user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] userValues = (string[])Session["UserValues"];
                lblWelcomeMessage.Text = $"Welcome, {userValues[1]}";

                //TODO: Get user for profile pic image
                switch (userValues[2])
                {
                    case "Client":
                        user = ClientSQLHelper.GetClientFromID(int.Parse(userValues[0]));
                        SetProfilePic();
                        ancHome.HRef = "ClientLandingPage.aspx";
                        break;
                    case "Contractor":
                        user = ContractorSQLHelper.GetContractorFromID(int.Parse(userValues[0]));
                        SetProfilePic();
                        ancHome.HRef = "ContractorLandingPage.aspx";
                        break;
                    case "Employee":
                        user = EmployeeSQLHelper.GetEmployeeFromID(int.Parse(userValues[0]));
                        SetProfilePic();
                        ancHome.HRef = "StaffLandingPage.aspx";
                        break;

                }
            }
        }

        private void SetProfilePic()
        {
            if(user.ProfilePicData != null)
            {
                string imageString64 = Convert.ToBase64String(user.ProfilePicData);
                btnProfilePic.ImageUrl = "data:Image/png;base64," + imageString64;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}