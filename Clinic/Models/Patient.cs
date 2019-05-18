using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string fname { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string mname { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

        [StringLength(50)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(300)]
        [Display(Name = "Password")]
        public string pass { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [StringLength(15)]
        [Display(Name = "Mobile")]
        public string mobile { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string display_name
        {
            get { return fname + " " + lname; }
            set { }
        }

        [StringLength(10)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime birthday { get; set; }

        [Display(Name = "Blood Type")]
        public string blood_type { get; set; }

        //image here 


        //insurance here
        [Display(Name = "Insurance Company")]
        public int insurance_id { get; set; }

        [ForeignKey("insurance_id")]
        public Insurance insurance { get; set; }
        

        public List<Consultation> consultations { get; set; }

        public string token { set; get; }

        [NotMapped]
        public IEnumerable<SelectListItem> BloodTypes { get; set; }


    }
}
