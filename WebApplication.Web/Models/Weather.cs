using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents the properties of weather model
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Represents the park code associated with the weather
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Represents a day within the 5 day forecast
        /// </summary>
        public int FiveDay { get; set; }

        /// <summary>
        /// Represents the low temperature from the database
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// Represents the converted low temperature based on the user's choice
        /// </summary>
        public int DisplayLow { get; set; }

        /// <summary>
        /// Represents the high temperature from the database
        /// </summary>
        public int High { get; set; }

        /// <summary>
        /// Represents the converted high temperature based on the user's choice
        /// </summary>
        public int DisplayHigh { get; set; }

        /// <summary>
        /// Represents the description of the day's weather
        /// </summary>
        public string Forecast { get; set; }

        /// <summary>
        /// Returns a suggestion based on the day's weather forecast
        /// </summary>
        /// <param name="forecast">description of the day's weather</param>
        /// <returns>suggestion</returns>
        public string ForecastSuggestionString(string forecast)
        {
            Dictionary<string, string> forecastSuggestion = new Dictionary<string, string>()
            {
                {"rain", "Pack rain gear and wear waterproof shoes"},
                {"snow","Pack snowshoes." },
                {"thunderstorms","Seek shelter and avoid hiking on exposed ridges."},
                {"sunny","Pack sunblock."},
                {"cloudy","Today is boring"},
                {"partly cloudy", "Today is partly boring"}
            };

            return forecastSuggestion[forecast];
        }

        /// <summary>
        /// Returns a suggestion based on the day's high/low temperatures
        /// </summary>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <returns>suggestions</returns>
        public string TempSuggestionString(int high, int low)
        {
            string suggestion = "";
            if(high>75)
            {
                suggestion = "Bring an extra gallon of water.";
            }

            if (low<20)
            {
                suggestion = "DANGER!!!! FRIGID temperatures.";
            }

            if ((high - low) > 20 )
            {
                suggestion = "Wear breathable layers.";
            }  
            return suggestion;
        }
    }
}
