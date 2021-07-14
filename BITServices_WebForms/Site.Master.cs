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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = username.Value;
            string pass = password.Value;

            Person user = UserSQLHelper.GetPersonFromUsername(userName);

            if(user != null)
            {
                if (user.Login(pass))
                {
                    string[] sessionValues;

                    switch (user.GetType().Name)
                    {
                        case "Client":
                            Client client = (Client)user;
                            sessionValues = new string[] { client.ClientID.ToString(), client.Name, "Client"};
                            Session["UserValues"] = sessionValues;

                            Response.Redirect("ClientLandingPage.aspx");
                            break;
                        case "Contractor":
                            Contractor contractor = (Contractor)user;
                            sessionValues = new string[] { contractor.ContractorID.ToString(), contractor.FirstName, "Contractor" };
                            Session["UserValues"] = sessionValues;

                            Response.Redirect("ContractorLandingPage.aspx");
                            break;
                        case "Employee":
                            Employee employee = (Employee)user;
                            sessionValues = new string[] { employee.EmployeeID.ToString(), employee.FirstName, "Employee" };
                            Session["UserValues"] = sessionValues;

                            Response.Redirect("StaffLandingPage.aspx");
                            break;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect username or password. Please try again');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Incorrect username or password. Please try again');</script>");
            }
        }
    }
}