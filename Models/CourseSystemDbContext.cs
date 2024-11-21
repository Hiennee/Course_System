using Microsoft.EntityFrameworkCore;

namespace Course_System.Models
{
    public class CourseSystemDbContext : DbContext
    {
        public CourseSystemDbContext(DbContextOptions<CourseSystemDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClassDetail> StudentClassDetails { get; set; }
        public DbSet<StudentRegister> StudentRegisters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.Email)
                .HasPrincipalKey<User>(u => u.Email);
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.Email)
                .HasPrincipalKey<User>(u => u.Email);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.Email)
                .HasPrincipalKey<User>(u => u.Email);
            modelBuilder.Entity<Tuition>()
                .HasKey(t => new
                {
                    t.StudentId,
                    t.ClassId,
                    t.SemesterId,
                });
        }
    }
}
