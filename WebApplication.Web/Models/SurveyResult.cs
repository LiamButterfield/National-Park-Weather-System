using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyResult
    {
        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        public int SurveyCount { get; set; }

        IList<Park> parks { get; set; } = new List<Park>();
    }
}
