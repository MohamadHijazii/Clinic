using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Doctor
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
        public string username { get; set; }

        [StringLength(300)]
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
        public string display_name { get; set; }

        [StringLength(10)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [StringLength(100)]
        [Display(Name = "Speciality")]
        public string speciality { get; set; }

        [StringLength(100)]
        [Display(Name = "Time")]
        public string time { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "About")]
        public string about { get; set; }


        [StringLength(10)]
        public string pr_phone { get; set; }

        [StringLength(10)]
        public string pr_mobile { get; set; }

        [StringLength(10)]
        [EmailAddress]
        public string pr_email { get; set; }

        [StringLength(10)]
        public string pr_mname { get; set; }

        [StringLength(10)]
        public string pr_address { get; set; }

        [StringLength(10)]
        public string pr_about { get; set; }

        [StringLength(10)]
        public string pr_time { get; set; }
    }
}
