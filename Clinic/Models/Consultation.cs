using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        [Display(Name = "Patient ID")]
        public int patient_id { get; set; }

        public int doctor_id { get; set; }


        [ForeignKey("patient_id")]
        public Patient patient { get; set; }

        [ForeignKey("doctor_id")]
        public Doctor doctor { get; set; }

        [StringLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [StringLength(50)]
        [Display(Name = "Type")]
        public string type { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Display(Name = "Symptoms")]
        public string symptoms { get; set; }

        [Display(Name = "Diagnosis")]
        public string diagnostics { get; set; }

        [StringLength(5)]
        [Display(Name = "Temp")]
        public string temp { get; set; }

        [StringLength(5)]
        [Display(Name ="Blood Presure")]
        public string blood_presure { get; set; }

        [StringLength(10)]
        [Display(Name = "Cost")]
        public string cost { get; set; }

        [Display(Name = "Treatment")]
        public string treatment { get; set; }

        [StringLength(10)]
        [Display(Name = "Insurance Confirmation")]
        public string insurance_conf { get; set; }
    }
}
