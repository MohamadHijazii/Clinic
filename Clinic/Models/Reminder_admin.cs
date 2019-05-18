using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Reminder_admin
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [StringLength(300)]
        [Display(Name = "Content")]
        public string content { get; set; }

        //[StringLength(10)]
        //public string priority { get; set; }

        [StringLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime time { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
    }
}
