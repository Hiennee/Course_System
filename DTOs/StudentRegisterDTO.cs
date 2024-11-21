namespace Course_System.DTOs
{
    public class StudentRegisterDTO
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
    }
}
