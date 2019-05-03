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
       // [Required]
        public string name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        //[Required]
        public string email { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone")]
      //  [Required]
        public string phone { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(300)]
       // [Required]
        public string pass { get; set; }

        [StringLength(100)]
        [Display(Name = "Address")]
        //[Required]
        public string address { get; set; }

        [StringLength(100)]
        public string fax { get; set; }

        public List<Report> reports { get; set; }

    }
}
