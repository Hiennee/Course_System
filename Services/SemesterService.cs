using Course_System.DTOs;
using Course_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_System.Services
{
    public class SemesterService
    {
        private readonly CourseSystemDbContext _context;
        public SemesterService(CourseSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Semester>> GetAllSemesters()
        {
            return await _context.Semesters.ToListAsync();
        }
        public async Task<Semester> GetSemesterById(string id)
        {
            return await _context.Semesters.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<ICollection<ClassDTO>> GetClassesInSemester(string id)
        {
            return await _context.Classes.Where(c => c.SemesterId.Equals(id)).Select(c => new ClassDTO
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
        public async Task<bool> AddSemester(string id)
        {
            try
            {
                await _context.Semesters.AddAsync(new Semester
                {
                    Id = id,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
