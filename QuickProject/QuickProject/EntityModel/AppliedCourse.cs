namespace EntityModel
{
    public class AppliedCourse : Course
    {
        public string StudentId { get; set; }
        public string AcadamicYearId { get; set; }
        public AcadamicYear AcadamicYear { get; set; }
        public double Fee { get; set; }
        public double ScholarShipDeduction { get; set; }
    }
  


}
