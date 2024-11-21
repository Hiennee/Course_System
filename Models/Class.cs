namespace Course_System.Models
{
    public class Class
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SemesterId { get; set; }
        public string Level { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TeacherId { get; set; }
        public string Shift { get; set; }
        public string Room { get; set; }
        public string? Room_addons { get; set; }
        public double TuitionMoney { get; set; }
        public Teacher Teacher { get; set; }
        public Semester Semester { get; set; }
    }
}
