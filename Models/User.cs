namespace Course_System.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Language { get; set; }
        public string IDNumber { get; set; }
        public Admin Admin { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
