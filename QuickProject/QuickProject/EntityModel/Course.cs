using System.Collections.Generic;

namespace EntityModel
{
    public class Course: BaseEntity<string>
    {
        public string CourseName { get; set; }
        public double Fees { get; set; }
        public int DurationInDays { get; set; }
        public string Details { get; set; }
        public ICollection<Subject> Subjects { get; set; }

    }
}
