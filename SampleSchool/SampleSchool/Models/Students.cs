using System;
using System.Collections.Generic;

namespace SampleSchool.Models
{
    public partial class Students
    {
        public Students()
        {
            Enrolment = new HashSet<Enrolment>();
        }

        public int Sid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public ICollection<Enrolment> Enrolment { get; set; }
    }
}
