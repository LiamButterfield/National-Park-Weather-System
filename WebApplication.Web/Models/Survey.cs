using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents the properties of survey model
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Represents survey's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the park code associated with the survey
        /// </summary>
        [Required]
        public string ParkCode { get; set; }

        /// <summary>
        /// User's Email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Represents the User's home location
        /// </summary>
        [Required]
        [MaxLength(30), MinLength(2)]
        public string State { get; set; }

        /// <summary>
        /// Represents the user's activity level
        /// </summary>
        [Required]
        public string ActivityLevel { get; set; }

        /// <summary>
        /// Represents the list of parks that are presented to the user
        /// </summary>
        IList<Park> parks { get; set; } = new List<Park>();
    }
}
