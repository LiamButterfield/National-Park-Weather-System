using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents the properties of park model
    /// </summary>
    public class Park
    {
        /// <summary>
        /// Represents the park's 5 day forecast
        /// </summary>
        public IList<Weather> Weathers { get; set; } = new List<Weather>();

        /// <summary>
        /// Represents the abbreviation of the park's name
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Represents the park's name
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// Represents park's location
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Represents the park's size
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// Represents the park's elevation
        /// </summary>
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// Represents the length of the park's trails
        /// </summary>
        public decimal MilesOfTrail { get; set; }

        /// <summary>
        /// Represents the park's number of campsite choices
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Represents the park's type of climate
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Represents the park's established year
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Represents the park's annual visitor count
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Represents the park's inspirational quote
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// Represents the park's inspirational quote's author
        /// </summary>
        public string QuoteSource { get; set; }

        /// <summary>
        /// Represents the park's description
        /// </summary>
        public string ParkDescription { get; set; }

        /// <summary>
        /// Represents the park's cost of entry
        /// </summary>
        public int EntryFee { get; set; }

        /// <summary>
        /// Represents the park's number of animal species
        /// </summary>
        public int AnimalSpecies { get; set; }
    }
}
