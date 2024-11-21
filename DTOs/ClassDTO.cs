namespace Course_System.DTOs
{
    public class ClassDTO
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
    }
}
