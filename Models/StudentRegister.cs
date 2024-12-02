namespace Course_System.Models
{
    public class StudentRegister
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAddress { get; set; }
        public string ClassId { get; set; }
        public string SemesterId { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string AdminEmail { get; set; }
        public Student Student { get; set; }
        public Course Class { get; set; }
        public Semester Semester { get; set; }
        public Admin Issuer { get; set; }
    }
}
