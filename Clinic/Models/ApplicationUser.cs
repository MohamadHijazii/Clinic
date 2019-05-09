using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class ApplicationUser : IdentityUser
    {

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string fname { get; set; }


        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string mname { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

    }
}
