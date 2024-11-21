namespace Course_System.Models
{
    public class StudentClassDetail
    {
        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public double Grade01 { get; set; }
        public double Grade02 { get; set; }
        public double Grade03 { get; set; }
        public double Grade04 { get; set; }
        public double Bonus { get; set; }
        public double GradeTotal { get; set; }
        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
