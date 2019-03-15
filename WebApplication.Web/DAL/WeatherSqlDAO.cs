using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString { get; set; }
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Provides a 5 day forecast for a specific park
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public IList<Weather> GetForecast(string parkCode)
        {
            IList<Weather> weathers = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather weather = ConvertReaderToWeather(reader);
                        weathers.Add(weather);
                    }
                }
            }

            catch (SqlException ex)
            {
                throw;
            }

            return weathers;
        }

        private Weather ConvertReaderToWeather(SqlDataReader reader)
        {
            Weather wea = new Weather();
            wea.ParkCode = Convert.ToString(reader["parkCode"]);
            wea.FiveDay = Convert.ToInt32(reader["fiveDayForecastValue"]);
            wea.Low = Convert.ToInt32(reader["low"]);
            wea.High = Convert.ToInt32(reader["high"]);
            wea.Forecast = Convert.ToString(reader["forecast"]);

            return wea;
        }
    }
}
