using System;
using System.Collections.Generic;

namespace SampleSchool.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrolment = new HashSet<Enrolment>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public int? Semester { get; set; }

        public ICollection<Enrolment> Enrolment { get; set; }
    }
}
