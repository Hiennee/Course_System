namespace Course_System.DTOs
{
    public class TuitionDTO
    {
        public string SemesterId { get; set; }
        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public double Money { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
