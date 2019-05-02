using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Assistant
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

        [Required]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Password")]
        public string pass { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(100)]
        public string display_name {
            get { return fname + " " + lname; }
            set { }
        }

        [Display(Name = "Relative Doctor")]
        public int ref_doctor { get; set; }

        [ForeignKey("ref_doctor")]
        public Doctor doctor { get; set; }
    }
}
