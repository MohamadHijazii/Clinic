using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Reminder_insurance
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [StringLength(300)]
        public string content { get; set; }

        [StringLength(10)]
        public string priority { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [DataType(DataType.Time)]
        public DateTime time { get; set; }

        public Insurance insurance { get; set; }



    }
}
