using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents the properties of survey result model
    /// </summary>
    public class SurveyResult
    {
        /// <summary>
        /// Represents the park code associated with the survey
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Represents the full park name display
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// Represents the number of surveys received by the individual park
        /// </summary>
        public int SurveyCount { get; set; }
    }
}
