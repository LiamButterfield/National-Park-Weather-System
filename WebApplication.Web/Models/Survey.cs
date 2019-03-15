using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(30), MinLength(2)]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        IList<Park> parks { get; set; } = new List<Park>();
    }
}
