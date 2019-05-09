using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Messages
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string message { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }


    }
}
