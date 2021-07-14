using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using BITServices_WebForms.Models;

namespace BITServices_WebForms.DAL
{
    class EmployeeSQLHelper : SQLHelper
    {
        public static List<Employee> GetAllEmployees()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetAllEmployees";

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            List<Employee> employeeList = new List<Employee>();
            foreach (DataRow dr in allEmployeeDT.Rows)
            {
                Employee employee = new Employee
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"],
                    EmployeeType = (string)dr["TypeName"]
                };
                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];                        //Database can't store images naturally, so they are converted to a binary array

                }catch(InvalidCastException)                                          //Catches if no image in database
                {
                    employee.ProfilePicData = null;
                }

                employeeList.Add(employee);
            }

            return employeeList;
        }

        public static Employee GetEmployeeFromUsername(string userName)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetEmployeeFromUsername";
            allEmployeeCmd.Parameters.Add(new SqlParameter("@Username", userName));

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            Employee employee;

            foreach(DataRow dr in allEmployeeDT.Rows)
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"],
                    EmployeeType = (string)dr["TypeName"]
                };
                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    employee.ProfilePicData = null;
                }

                return employee;
            }

            return null;
        }

        public static Employee GetEmployeeFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allEmployeeCmd = new SqlCommand();
            allEmployeeCmd.Connection = BITConn;
            allEmployeeCmd.CommandType = CommandType.StoredProcedure;
            allEmployeeCmd.CommandText = "uspGetEmployeeFromID";
            allEmployeeCmd.Parameters.Add(new SqlParameter("@ID", id));

            SqlDataAdapter allEmployeesAdapt = new SqlDataAdapter(allEmployeeCmd);
            allEmployeeCmd.Connection.Close();
            DataTable allEmployeeDT = new DataTable();
            allEmployeesAdapt.Fill(allEmployeeDT);

            Employee employee;

            foreach (DataRow dr in allEmployeeDT.Rows)
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    FirstName = (string)dr["FirstName"],
                    LastName = (string)dr["LastName"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"],
                    EmployeeType = (string)dr["TypeName"]
                };
                try
                {
                    employee.ProfilePicData = (byte[])dr["EmployeeImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    employee.ProfilePicData = null;
                }

                return employee;
            }

            return null;
        }
    }
}
