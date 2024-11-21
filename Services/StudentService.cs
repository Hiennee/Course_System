using Course_System.DTOs;
using Course_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_System.Services
{
    public class StudentService
    {
        private readonly CourseSystemDbContext _context;
        public StudentService(CourseSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<StudentDTO>> GetAllStudents()
        {
            return await _context.Students.Select(s => new StudentDTO
            {
                UserId = s.UserId,
                Email = s.Email,
                ParentPhone = s.ParentPhone,
            }).ToListAsync();
        }
        public async Task<ICollection<StudentDTO>> GetStudentsByName(string name)
        {
            var accountStudents = await _context.Users.Where(u => (u.FirstName + u.LastName).Contains(name))
                                                      .Select(u => u.Id).ToListAsync();
            return await _context.Students.Where(s => accountStudents.Contains(s.UserId)).Select(s => new StudentDTO
            {
                UserId = s.UserId,
                Email = s.Email,
                ParentPhone = s.ParentPhone,
            }).ToListAsync();
        }
        public async Task<StudentDTO> GetStudentById(string id)
        {
            return await _context.Students.Where(s => s.UserId.Equals(id)).Select(s => new StudentDTO
            {
                UserId = s.UserId,
                Email = s.Email,
                ParentPhone = s.ParentPhone,
            }).FirstOrDefaultAsync();
        }
        public async Task<bool> AddStudent(StudentDTO student)
        {
            try
            {
                await _context.Students.AddAsync(new Student
                {
                    UserId = student.UserId,
                    Email = student.Email,
                    ParentPhone = student.ParentPhone,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<ICollection<ClassDTO>> GetClassesOfStudent(string studentId)
        {
            var classesId = await _context.StudentClassDetails.Where(scd => scd.StudentId.Equals(studentId))
                                                              .Select(scd => scd.ClassId).ToListAsync();
            return await _context.Classes.Where(c => classesId.Contains(c.Id)).Select(c => new ClassDTO
            {
                Id = c.Id,
                Name = c.Name,
                SemesterId = c.SemesterId,
                Level = c.Level,
                Subject = c.Subject,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                TeacherId = c.TeacherId,
                Shift = c.Shift,
                Room = c.Room,
                Room_addons = c.Room_addons,
                TuitionMoney = c.TuitionMoney,
            }).ToListAsync();
        }
    }
}
