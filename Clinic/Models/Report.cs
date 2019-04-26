using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Key]
        public Patient patient { get; set; }

        [Key]
        public Doctor doctor { get; set; }

        [Key]
        public Insurance insurance { get; set; }

        [StringLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [StringLength(10)]
        [Display(Name = "COST")]
        public string cost { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

       
    }
}
