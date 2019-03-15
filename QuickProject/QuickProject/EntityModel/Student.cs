using System.Collections.Generic;
using System.Linq;

namespace EntityModel
{
    public class Student : BaseEntity<string>, IPerson
    {
        public string EnrollmentNumber { get; set; }
        public string MotherId { get; set; }
        public string FatherId { get; set; }
        public Person Mother { get; set; }
        public Person Father { get; set; }
        public ICollection<AppliedCourse> Courses { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public double Dues => Courses.Sum(i => i.Fee) - Courses.Sum(i => i.ScholarShipDeduction) - Payments.Where(i => i.PaymentType == PaymentType.FEE_PAID).Sum(i => i.PaidAmount);

        public string FirstName { get;set; }
        public string MiddleName { get;set; }
        public string LastName { get;set; }
        public string Title { get;set; }
        public string Email { get;set; }
        public string PhoneNumber { get;set; }
        public string MobileNumber { get;set; }
        public string Address_1 { get;set; }
        public string Address_2 { get;set; }
        public string City { get;set; }
        public string State { get;set; }
        public string Country { get;set; }
        public string PostalCode { get;set; }
        public string FaxNumber { get;set; }
        public string Comments_Summary { get;set; }
    }
    

}
