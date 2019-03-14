using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private string connectionString { get; set; }
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool CreateSurvey(Survey survey)
        {
            bool saved = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw;
            }

            return saved;
        }

        public IList<SurveyResult> Results()
        {
            IList<SurveyResult> results = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT survey_result.parkCode, park.parkName, COUNT(survey_result.parkCode) AS favorite FROM survey_result
                                                        JOIN park ON(park.parkCode = survey_result.parkCode)
                                                        GROUP BY survey_result.parkCode, park.parkName ORDER By favorite DESC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SurveyResult survey = ConvertReaderToSurveyResults(reader);
                        results.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return results;
        }

        private SurveyResult ConvertReaderToSurveyResults(SqlDataReader reader)
        {
            SurveyResult survey = new SurveyResult();
            survey.ParkCode = Convert.ToString(reader["parkCode"]);
            survey.SurveyCount = Convert.ToInt32(reader["favorite"]);
            survey.ParkName = Convert.ToString(reader["parkName"]);
            return survey;
        }
    }
}
