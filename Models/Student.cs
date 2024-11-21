namespace Course_System.Models
{
    public class Student
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string ParentPhone { get; set; }
        public User User { get; set; }
    }
}
