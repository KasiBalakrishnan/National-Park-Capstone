﻿using Capstone.Web.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString;
        private const string SQL_InsertNewSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) values((@parkCode),(@emailAddress),(@state),(@activityLevel));";
        private const string SQL_GetLeadParks = @"SELECT  park.parkName, COUNT(survey_result.parkCode) AS parksCount
                                                FROM survey_result 
                                                JOIN park ON park.parkCode=survey_result.parkCode 
                                                GROUP BY park.parkName ORDER BY COUNT(park.parkName) desc;";
        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Dictionary<string, int> GetLeadParks()
        {
            Dictionary<string, int> leadingParks = new Dictionary<string, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetLeadParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        leadingParks.Add(Convert.ToString(reader["parkName"]), Convert.ToInt32(reader["parksCount"]));
                    }
                    return leadingParks;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddSurvey(SurveyModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_InsertNewSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}