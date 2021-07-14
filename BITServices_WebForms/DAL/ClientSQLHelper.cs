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
    class ClientSQLHelper : SQLHelper
    {
        public static List<Client> GetAllClients()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allClientCmd = new SqlCommand();
            allClientCmd.Connection = BITConn;
            allClientCmd.CommandType = CommandType.StoredProcedure;
            allClientCmd.CommandText = "uspGetAllClients";

            SqlDataAdapter allClientAdapt = new SqlDataAdapter(allClientCmd);
            allClientCmd.Connection.Close();
            DataTable allClientDT = new DataTable();
            allClientAdapt.Fill(allClientDT);

            List<Client> clientList = new List<Client>();
            foreach (DataRow dr in allClientDT.Rows)
            {
                Client client = new Client
                {
                    ClientID = (int)dr["ClientID"],
                    Name = (string)dr["Name"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"]
                };
                try
                {
                    client.ProfilePicData = (byte[])dr["ClientImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    client.ProfilePicData = null;
                }

                clientList.Add(client);
            }

            return clientList;
        }

        public static Client GetClientFromUsername(string userName)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allClientCmd = new SqlCommand();
            allClientCmd.Connection = BITConn;
            allClientCmd.CommandType = CommandType.StoredProcedure;
            allClientCmd.CommandText = "uspGetClientFromUsername";
            allClientCmd.Parameters.Add(new SqlParameter("@Username", userName));

            SqlDataAdapter allClientAdapt = new SqlDataAdapter(allClientCmd);
            allClientCmd.Connection.Close();
            DataTable allClientDT = new DataTable();
            allClientAdapt.Fill(allClientDT);

            Client client;
            foreach (DataRow dr in allClientDT.Rows)
            {
                client = new Client
                {
                    ClientID = (int)dr["ClientID"],
                    Name = (string)dr["Name"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"]
                };
                try
                {
                    client.ProfilePicData = (byte[])dr["ClientImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    client.ProfilePicData = null;
                }

                return client;
            }

            return null;
        }

        public static Client GetClientFromID(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allClientCmd = new SqlCommand();
            allClientCmd.Connection = BITConn;
            allClientCmd.CommandType = CommandType.StoredProcedure;
            allClientCmd.CommandText = "uspGetClientFromID";
            allClientCmd.Parameters.Add(new SqlParameter("@ID", id));

            SqlDataAdapter allClientAdapt = new SqlDataAdapter(allClientCmd);
            allClientCmd.Connection.Close();
            DataTable allClientDT = new DataTable();
            allClientAdapt.Fill(allClientDT);

            Client client;
            foreach (DataRow dr in allClientDT.Rows)
            {
                client = new Client
                {
                    ClientID = (int)dr["ClientID"],
                    Name = (string)dr["Name"],
                    Street = (string)dr["Street"],
                    Suburb = (string)dr["Suburb"],
                    State = (string)dr["State"],
                    PostCode = (string)dr["PostCode"],
                    PhoneNumber = (string)dr["PhoneNumber"],
                    MobileNumber = (string)dr["MobilePhoneNumber"],
                    Email = (string)dr["Email"],
                    Username = (string)dr["Username"],
                    PasswordHash = (string)dr["PasswordHash"],
                    PasswordSalt = (string)dr["PasswordSalt"]
                };
                try
                {
                    client.ProfilePicData = (byte[])dr["ClientImage"];                        //Database can't store images naturally, so they are converted to a binary array
                }
                catch (InvalidCastException)                                          //Catches if no image in database
                {
                    client.ProfilePicData = null;
                }

                return client;
            }

            return null;
        }

        public static DataTable GetActiveClientJobs(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allActiveJobCmd = new SqlCommand();
            allActiveJobCmd.Connection = BITConn;
            allActiveJobCmd.CommandType = CommandType.StoredProcedure;
            allActiveJobCmd.CommandText = "uspGetActiveClientJobs";
            allActiveJobCmd.Parameters.Add(new SqlParameter("@ClientID", id));

            SqlDataAdapter allActiveJobAdapt = new SqlDataAdapter(allActiveJobCmd);
            allActiveJobCmd.Connection.Close();
            DataTable allActiveJobDT = new DataTable();
            allActiveJobAdapt.Fill(allActiveJobDT);

            return allActiveJobDT;
        }

        public static DataTable GetAllClientJobs(int id)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allActiveJobCmd = new SqlCommand();
            allActiveJobCmd.Connection = BITConn;
            allActiveJobCmd.CommandType = CommandType.StoredProcedure;
            allActiveJobCmd.CommandText = "uspGetAllClientJobs";
            allActiveJobCmd.Parameters.Add(new SqlParameter("@ClientID", id));

            SqlDataAdapter allActiveJobAdapt = new SqlDataAdapter(allActiveJobCmd);
            allActiveJobCmd.Connection.Close();
            DataTable allActiveJobDT = new DataTable();
            allActiveJobAdapt.Fill(allActiveJobDT);

            return allActiveJobDT;
        }

        
    }
    
}