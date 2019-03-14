using System.Collections.Generic;
using System.Linq;

namespace EntityModel
{
    public class Student : Person
    {
        public string EnrollmentNumber { get; set; }
        public string MotherId { get; set; }
        public string FatherId { get; set; }
        public Person Mother { get; set; }
        public Person Father { get; set; }
        public ICollection<AppliedCourse> Courses { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public double Dues => Courses.Sum(i => i.Fee) - Courses.Sum(i => i.ScholarShipDeduction) - Payments.Where(i => i.PaymentType == PaymentType.FEE_PAID).Sum(i => i.PaidAmount);

    }
    

}
