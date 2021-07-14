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
    class ContractorSQLHelper : SQLHelper
    {
        public static List<Contractor> GetAllContractors()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetAllContractors";

            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            List<Contractor> contractorList = new List<Contractor>();
            foreach (DataRow dr in allContractorDT.Rows)
            {
                Contractor contractor = new Contractor
                {
                    ContractorID = (int)dr["Contractor_ID"],
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
                    Rating = dr["Rating"] != DBNull.Value ? Convert.ToInt32(dr["Rating"]) : 0
                };
                try
                {
                    contractor.ProfilePicData = (byte[])dr["ContractorImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    contractor.ProfilePicData = null;
                }

                contractorList.Add(contractor);
            }

            return contractorList;
        }

        public static DataTable GetAllContractorsTable()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetAllContractors";

            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            return allContractorDT;
        }

        public static Contractor GetContractorFromUsername(string userName)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetContractorFromUsername";
            allContractorCmd.Parameters.Add(new SqlParameter("@Username", userName));

            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            Contractor contractor;

            foreach (DataRow dr in allContractorDT.Rows)
            {
                contractor = new Contractor
                {
                    ContractorID = (int)dr["Contractor_ID"],
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
                    Rating = dr["Rating"] != DBNull.Value ? Convert.ToInt32(dr["Rating"]) : 0
                };
                try
                {
                    contractor.ProfilePicData = (byte[])dr["ContractorImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    contractor.ProfilePicData = null;
                }

                return contractor;
            }

            return null;
        }

        public static Contractor GetContractorFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetContractorFromID";
            allContractorCmd.Parameters.Add(new SqlParameter("@ID", id));

            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            Contractor contractor;

            foreach (DataRow dr in allContractorDT.Rows)
            {
                contractor = new Contractor
                {
                    ContractorID = (int)dr["Contractor_ID"],
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
                    Rating = dr["Rating"] != DBNull.Value ? Convert.ToInt32(dr["Rating"]) : 0
                };
                try
                {
                    contractor.ProfilePicData = (byte[])dr["ContractorImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    contractor.ProfilePicData = null;
                }

                return contractor;
            }

            return null;
        }

        public static DataTable GetAssignableContractors(string skill, string state)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allContractorCmd = new SqlCommand();
            allContractorCmd.Connection = BITConn;
            allContractorCmd.CommandType = CommandType.StoredProcedure;
            allContractorCmd.CommandText = "uspGetAssignableContractors";
            allContractorCmd.Parameters.AddWithValue("@SkillName", skill);
            allContractorCmd.Parameters.AddWithValue("@State", state);
            SqlDataAdapter allContractorAdapt = new SqlDataAdapter(allContractorCmd);
            allContractorCmd.Connection.Close();
            DataTable allContractorDT = new DataTable();
            allContractorAdapt.Fill(allContractorDT);

            return allContractorDT;
        }

        public static DataTable GetAllContractorJobs(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allJobCmd = new SqlCommand();
            allJobCmd.Connection = BITConn;
            allJobCmd.CommandType = CommandType.StoredProcedure;
            allJobCmd.CommandText = "uspGetAllContractorJobs";
            allJobCmd.Parameters.AddWithValue("@ContractorID", id);

            SqlDataAdapter allJobAdapt = new SqlDataAdapter(allJobCmd);
            allJobCmd.Connection.Close();
            DataTable allJobDT = new DataTable();
            allJobAdapt.Fill(allJobDT);

            return allJobDT;
        }
    }
}