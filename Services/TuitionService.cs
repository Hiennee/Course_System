using Course_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_System.Services
{
    public class TuitionService
    {
        private readonly CourseSystemDbContext _context;
        public TuitionService(CourseSystemDbContext context)
        {
            _context = context;
        }
        public async Task<double> GetStudentTuitionInfo(string studentId, string semesterId)
        {
            return await _context.Tuitions.Where(t => t.StudentId.Equals(studentId))
                                          .Where(t => t.SemesterId.Equals(semesterId))
                                          .Select(t => t.Money).FirstOrDefaultAsync();
        }
        public async Task<DateTime> GetStudentTuitionDue(string studentId, string semesterId)
        {
            return await _context.Tuitions.Where(t => t.StudentId.Equals(studentId))
                                          .Where(t => t.SemesterId.Equals(semesterId))
                                          .Select(t => t.DueDate).FirstOrDefaultAsync();
        }
    }
}
