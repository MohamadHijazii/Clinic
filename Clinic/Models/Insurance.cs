using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(300)]
        public string pass { get; set; }

        [StringLength(100)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [StringLength(100)]
        public string fax { get; set; }
    }
}
