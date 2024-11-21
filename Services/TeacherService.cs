using Course_System.DTOs;
using Course_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_System.Services
{
    public class TeacherService
    {
        private readonly CourseSystemDbContext _context;
        public TeacherService(CourseSystemDbContext context)
        {
            _context = context;
        }
        private async Task<ICollection<TeacherDTO>> GetAllTeachers()
        {
            return await _context.Teachers.Select(t => new TeacherDTO
            {
                UserId = t.UserId,
                Email = t.Email,
                ContractStart = t.ContractStart,
                ContractEnd = t.ContractEnd,
            }).ToListAsync();
        }
        private async Task<TeacherDTO> GetTeacherById(string id)
        {
            return await _context.Teachers.Where(t => t.UserId.Equals(id)).Select(t => new TeacherDTO
            {
                UserId = t.UserId,
                Email = t.Email,
                ContractStart = t.ContractStart,
                ContractEnd = t.ContractEnd,
            }).FirstOrDefaultAsync();
        }
        private async Task<ICollection<TeacherDTO>> GetTeachersByName(string name)
        {
            return await _context.Users.Where(u => (u.FirstName + u.LastName).Contains(name)).Select(u => new TeacherDTO
            {
                UserId = u.Teacher.UserId,
                Email = u.Teacher.Email,
                ContractStart = u.Teacher.ContractStart,
                ContractEnd = u.Teacher.ContractEnd,
            }).ToListAsync();
        }
        private async Task<List<DateTime>> GetTeacherContractStatus(string teacherId)
        {
            //[0]: start, [1]: end;
            return await _context.Teachers.Where(t => t.UserId.Equals(teacherId)).Select(t => new List<DateTime>
            {
                t.ContractStart,
                t.ContractEnd,
            }).FirstOrDefaultAsync();
        }
    }
}
