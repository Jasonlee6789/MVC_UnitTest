using System;
using System.Collections.Generic;

namespace SampleSchool.Models
{
    public partial class Enrolment
    {
        public int EnrolId { get; set; }
        public int Sid { get; set; }
        public string CourseId { get; set; }
        public int EnrolmentYear { get; set; }
        public int EnrolmentSemester { get; set; }

        public Course Course { get; set; }
        public Students S { get; set; }
    }
}
