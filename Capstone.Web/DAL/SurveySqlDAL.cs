using Capstone.Web.Models;
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
        private const string SQL_GetPosts = "SELECT * FROM survey_result;";
        private const string SQL_InsertNewSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) values((@parkCode),(@emailAddress),(@state),(@activityLevel));";
        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SurveyModel> GetResults()
        {
            List<SurveyModel> output = new List<SurveyModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetPosts, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyModel p = new SurveyModel()
                        {
                            SurveyID = Convert.ToInt32(reader["surveyID"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            EmailAddress = Convert.ToString(reader["emailAddress"]),
                            State = Convert.ToString(reader["state"]),
                            ActivityLevel = Convert.ToString(reader["activityLevel"]),
                        };

                        output.Add(p);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
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
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}