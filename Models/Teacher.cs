namespace Course_System.Models
{
    public class Teacher
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public User User { get; set; }
    }
}
