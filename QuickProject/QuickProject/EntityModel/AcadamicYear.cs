using System;
using System.Collections.Generic;

namespace EntityModel
{
    public class AcadamicYear : BaseEntity<string>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
