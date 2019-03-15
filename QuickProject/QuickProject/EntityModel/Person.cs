namespace EntityModel
{
    public class Person : BaseEntity<string>, IPerson
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string FaxNumber { get; set; }
        public string Comments_Summary { get; set; }
     

    }
    public interface IPerson
    {
         string FirstName { get; set; }
         string MiddleName { get; set; }
         string LastName { get; set; }
         string Title { get; set; }
         string Email { get; set; }
         string PhoneNumber { get; set; }
         string MobileNumber { get; set; }
         string Address_1 { get; set; }
         string Address_2 { get; set; }
         string City { get; set; }
         string State { get; set; }
         string Country { get; set; }
         string PostalCode { get; set; }
         string FaxNumber { get; set; }
         string Comments_Summary { get; set; }
    }

}
