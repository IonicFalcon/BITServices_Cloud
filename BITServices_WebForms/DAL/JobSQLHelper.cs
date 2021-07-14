using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BITServices_WebForms.Models;

namespace BITServices_WebForms.DAL
{
    class JobSQLHelper : SQLHelper
    {
        public static DataTable GetAllJobs()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand allJobsCmd = new SqlCommand();
            allJobsCmd.Connection = BITConn;
            allJobsCmd.CommandType = CommandType.StoredProcedure;
            allJobsCmd.CommandText = "uspGetAllJobs";

            SqlDataAdapter allJobsAdapt = new SqlDataAdapter(allJobsCmd);
            allJobsCmd.Connection.Close();
            DataTable allJobsDT = new DataTable();
            allJobsAdapt.Fill(allJobsDT);

            return allJobsDT;
        }

        public static DataTable GetJobsForAssignment()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand jobsForAssignCmd = new SqlCommand();
            jobsForAssignCmd.Connection = BITConn;
            jobsForAssignCmd.CommandType = CommandType.StoredProcedure;
            jobsForAssignCmd.CommandText = "uspGetJobsForAssignment";

            SqlDataAdapter jobsForAssignAdapt = new SqlDataAdapter(jobsForAssignCmd);
            jobsForAssignCmd.Connection.Close();
            DataTable jobsForAssignDT = new DataTable();
            jobsForAssignAdapt.Fill(jobsForAssignDT);

            return jobsForAssignDT;
        }

        public static DataTable GetJobsForAcceptance(int contractorID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand jobsForAcceptCmd = new SqlCommand();
            jobsForAcceptCmd.Connection = BITConn;
            jobsForAcceptCmd.CommandType = CommandType.StoredProcedure;
            jobsForAcceptCmd.CommandText = "uspGetJobsForAcceptance";
            jobsForAcceptCmd.Parameters.AddWithValue("@ContractorID", contractorID);

            SqlDataAdapter jobsForAcceptAdapt = new SqlDataAdapter(jobsForAcceptCmd);
            jobsForAcceptCmd.Connection.Close();
            DataTable jobsForAcceptDT = new DataTable();
            jobsForAcceptAdapt.Fill(jobsForAcceptDT);

            return jobsForAcceptDT;
        }

        public static DataTable GetJobsForCompletion(int contractorID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand jobsForCompleteCmd = new SqlCommand();
            jobsForCompleteCmd.Connection = BITConn;
            jobsForCompleteCmd.CommandType = CommandType.StoredProcedure;
            jobsForCompleteCmd.CommandText = "uspGetJobsForCompletion";
            jobsForCompleteCmd.Parameters.AddWithValue("@ContractorID", contractorID);

            SqlDataAdapter jobsForCompleteAdapt = new SqlDataAdapter(jobsForCompleteCmd);
            jobsForCompleteCmd.Connection.Close();
            DataTable jobsForCompleteDT = new DataTable();
            jobsForCompleteAdapt.Fill(jobsForCompleteDT);

            return jobsForCompleteDT;
        }

        public static DataTable GetJobsForVerification()
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand jobsForVerifyCmd = new SqlCommand();
            jobsForVerifyCmd.Connection = BITConn;
            jobsForVerifyCmd.CommandType = CommandType.StoredProcedure;
            jobsForVerifyCmd.CommandText = "uspGetJobsForVerification";

            SqlDataAdapter jobsForVerifyAdapt = new SqlDataAdapter(jobsForVerifyCmd);
            jobsForVerifyCmd.Connection.Close();
            DataTable jobsForVerifyDT = new DataTable();
            jobsForVerifyAdapt.Fill(jobsForVerifyDT);

            return jobsForVerifyDT;
        }

        public static int CreateJob(Job newJob)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand addJobCmd = new SqlCommand();
            addJobCmd.Connection = BITConn;
            addJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "INSERT INTO Job(JobDate, JobStartTime, ClientID, JobStreet, JobSuburb, JobState, JobPostCode, JobUrgency, SkillName, JobDetails, JobStatus) VALUES (@JobDate, @JobStartTime, @ClientID, @JobStreet, @JobSuburb, @JobState, @JobPostCode, @JobUrgency, @SkillName, @JobDetails, @JobStatus)";

            addJobCmd.CommandText = sqlQuery;
            try
            {
                addJobCmd.Parameters.AddWithValue("@JobDate", newJob.StartDateTime.Date);
                addJobCmd.Parameters.AddWithValue("@JobStartTime", newJob.StartDateTime.ToString("HH:mm"));
                addJobCmd.Parameters.AddWithValue("@ClientID", newJob.JobClient.ClientID);
                addJobCmd.Parameters.AddWithValue("@JobStreet", newJob.Street);
                addJobCmd.Parameters.AddWithValue("@JobSuburb", newJob.Suburb);
                addJobCmd.Parameters.AddWithValue("@JobState", newJob.State);
                addJobCmd.Parameters.AddWithValue("@JobPostCode", newJob.PostCode);
                addJobCmd.Parameters.AddWithValue("@JobUrgency", newJob.Urgency);
                addJobCmd.Parameters.AddWithValue("@SkillName", newJob.SkillType);
                addJobCmd.Parameters.AddWithValue("@JobDetails", newJob.JobDetails);
                addJobCmd.Parameters.AddWithValue("@JobStatus", "Active");

                return addJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int AssignJob(DateTime date, string startTime, string clientID, string contractorID, string employeeID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand assignJobCmd = new SqlCommand();
            assignJobCmd.Connection = BITConn;
            assignJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET ContractorID = @ContractorID, AssignedEmployee = @EmployeeID, JobStatus = 'Active' WHERE JobDate = @JobDate AND JobStartTime = @StartTime AND ClientID = @ClientID";

            assignJobCmd.CommandText = sqlQuery;

            try
            {
                assignJobCmd.Parameters.AddWithValue("@ContractorID", contractorID);
                assignJobCmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                assignJobCmd.Parameters.AddWithValue("@JobDate", date);
                assignJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                assignJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return assignJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int DeleteJob(DateTime date, string startTime, string clientID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand deleteJobCmd = new SqlCommand();
            deleteJobCmd.Connection = BITConn;
            deleteJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "DELETE FROM Job WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            deleteJobCmd.CommandText = sqlQuery;

            try
            {
                deleteJobCmd.Parameters.AddWithValue("@Date", date);
                deleteJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                deleteJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return deleteJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int AcceptJob(DateTime date, string startTime, string clientID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand acceptJobCmd = new SqlCommand();
            acceptJobCmd.Connection = BITConn;
            acceptJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET JobStatus = 'Accepted' WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            acceptJobCmd.CommandText = sqlQuery;

            try
            {
                acceptJobCmd.Parameters.AddWithValue("@Date", date);
                acceptJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                acceptJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return acceptJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int RejectJob(DateTime date, string startTime, string clientID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand rejectJobCmd = new SqlCommand();
            rejectJobCmd.Connection = BITConn;
            rejectJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET JobStatus = 'Rejected' WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            rejectJobCmd.CommandText = sqlQuery;

            try
            {
                rejectJobCmd.Parameters.AddWithValue("@Date", date);
                rejectJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                rejectJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return rejectJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int CompleteJob(DateTime date, string startTime, string clientID, string endTime, string distanceTravelled)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand completeJobCmd = new SqlCommand();
            completeJobCmd.Connection = BITConn;
            completeJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET EndTime = @EndTime, DistanceTravelled = @DistanceTravelled, JobStatus = 'Completed' WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            completeJobCmd.CommandText = sqlQuery;

            try
            {
                completeJobCmd.Parameters.AddWithValue("@EndTime", endTime);
                completeJobCmd.Parameters.AddWithValue("@DistanceTravelled", distanceTravelled);
                completeJobCmd.Parameters.AddWithValue("@Date", date);
                completeJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                completeJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return completeJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int VerifyJob(DateTime date, string startTime, string clientID)
        {
            ConnectDB();
            BITConn.Open();
            SqlCommand verifyJobCmd = new SqlCommand();
            verifyJobCmd.Connection = BITConn;
            verifyJobCmd.CommandType = CommandType.Text;

            string sqlQuery = "UPDATE Job SET JobStatus = 'Verify' WHERE JobDate = @Date AND JobStartTime = @StartTime AND ClientID = @ClientID";

            verifyJobCmd.CommandText = sqlQuery;

            try
            {
                verifyJobCmd.Parameters.AddWithValue("@Date", date);
                verifyJobCmd.Parameters.AddWithValue("@StartTime", startTime);
                verifyJobCmd.Parameters.AddWithValue("@ClientID", clientID);

                return verifyJobCmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }
    }
}