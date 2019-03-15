using System.Collections.Generic;

namespace EntityModel
{
    public class AppliedCourse : BaseEntity<string>, ICourse
    {
        public string StudentId { get; set; }
        public string AcadamicYearId { get; set; }
        public AcadamicYear AcadamicYear { get; set; }
        public double Fee { get; set; }
        public double ScholarShipDeduction { get; set; }
        public string CourseName { get; set; }
        public double Fees { get; set; }
        public int DurationInDays { get; set; }
        public string Details { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
  


}
