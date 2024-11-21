namespace Course_System.Models
{
    public class Tuition
    {
        public string SemesterId { get; set; }
        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public double Money { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Semester Semester { get; set; }
        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
