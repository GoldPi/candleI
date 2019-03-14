namespace EntityModel
{
    public class Subject : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Syllabus { get; set; }
        public bool IsPractical { get; set; }
        public bool IsTheory { get; set; }
    }
}
