using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }

        public int FiveDay { get; set; }

        public int Low { get; set; }

        public int High { get; set; }

        public string Forecast { get; set; }

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
