using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Admin
    {
        
        public int Id { get; set; }
        
        [Display(Name ="First Name")]
        [StringLength(50)]
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
        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [StringLength(15)]
        [Display(Name = "Mobile Number")]
        public string mobile { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(100)]
        public string rand_pass { get; set; }

        public DateTime exp_pass { get; set; }
    }
}
