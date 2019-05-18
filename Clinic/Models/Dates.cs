using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Dates
    {
        public int Id { get; set; }

        [Display(Name = "Patient ID")]
        public int patient_id { get; set; }

        [ForeignKey("patient_id")]       
        public Patient patient { get; set; }

        public Doctor doctor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Select a Date")]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]

        [Display(Name = "Select a time")]
        public DateTime time { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(20)]
        public string alpha { get; set; }


    }
}
