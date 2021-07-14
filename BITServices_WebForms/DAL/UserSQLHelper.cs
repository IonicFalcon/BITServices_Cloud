using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using BITServices_WebForms.Models;

namespace BITServices_WebForms.DAL
{
    class UserSQLHelper : SQLHelper
    {
        public static Person GetPersonFromUsername(string enteredUsername)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allPersonCmd = new SqlCommand();
            allPersonCmd.Connection = BITConn;
            allPersonCmd.CommandType = CommandType.StoredProcedure;
            allPersonCmd.CommandText = "uspGetUserFromUsername";
            allPersonCmd.Parameters.Add(new SqlParameter("@Username", enteredUsername));

            SqlDataAdapter allPersonAdapt = new SqlDataAdapter(allPersonCmd);
            allPersonCmd.Connection.Close();
            DataTable allPersonDT = new DataTable();
            allPersonAdapt.Fill(allPersonDT);

            Person returnPerson;

            if (allPersonDT != null)
            {
                foreach (DataRow dr in allPersonDT.Rows)
                {
                    string tableName = (string)dr["TableName"];
                    string userName = (string)dr["Username"];

                    switch (tableName)
                    {
                        case "Employee":
                            returnPerson = EmployeeSQLHelper.GetEmployeeFromUsername(userName);
                            return returnPerson;
                        case "Contractor":
                            returnPerson = ContractorSQLHelper.GetContractorFromUsername(userName);
                            return returnPerson;
                        case "Client":
                            returnPerson = ClientSQLHelper.GetClientFromUsername(userName);
                            return returnPerson;
                    }
                }
            }

            return null;
        }
    }
}