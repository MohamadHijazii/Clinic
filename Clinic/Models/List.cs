using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class List
    {
        public int Id { get; set; }

        public Patient patient { get; set; }

        public Doctor doctor { get; set; }
    }
}
