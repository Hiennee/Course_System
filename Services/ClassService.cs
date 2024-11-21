using Course_System.DTOs;
using Course_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_System.Services
{
    public class ClassService
    {
        private readonly CourseSystemDbContext _context;
        public ClassService(CourseSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ClassDTO>> GetAllClasses()
        {
            return await _context.Classes.Select(c =>
                new ClassDTO
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
                }
            ).ToListAsync();
        }
        public async Task<ClassDTO> GetClassById(string id)
        {
            return await _context.Classes.Where(c => c.Id == id).Select(c =>
                new ClassDTO
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
            }).FirstOrDefaultAsync();
        }
        public async Task<ICollection<ClassDTO>> GetClassesByName(string name)
        {
            return await _context.Classes.Where(c => c.Name.Contains(name)).Select(c => 
            new ClassDTO
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
        public async Task<ICollection<UserDTO>> GetAllStudentsInClass(string classId)
        {
            List<string> studentsIdInClass = await _context.StudentClassDetails.Where(scd => scd.ClassId.Equals(classId))
                                                     .Select(scd => scd.StudentId).ToListAsync();
            return await _context.Users.Where(u => studentsIdInClass.Contains(u.Id))
                .Select(u => 
                    new UserDTO
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Role = u.Role,
                        Gender = u.Gender,
                        Email = u.Email,
                        Phone = u.Phone,
                        DOB = u.DOB,
                    }).ToListAsync();                                        
        }
        public async Task<ICollection<ClassDTO>> GetClassesOfTeacher(string teacherId)
        {
            return await _context.Classes.Where(c => c.TeacherId.Equals(teacherId)).Select(c => new ClassDTO
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
        public async Task<double> GetClassTuition(string classId)
        {
            return await _context.Classes.Where(c => c.Id == classId).Select(c => c.TuitionMoney).FirstOrDefaultAsync();
        }
        private async void InsertClass(string classId, string className, string semesterId, string level,
                                       string subject, DateTime start, DateTime end, string teacherId,
                                       string shift, string room, string? room_addons)
        {
            await _context.Classes.AddAsync(new Class
            {
                Id = classId,
                Name = className,
                SemesterId = semesterId,
                Level = level,
                Subject = subject,
                StartDate = start,
                EndDate = end,
                TeacherId = teacherId,
                Shift = shift,
                Room = room,
                Room_addons = room_addons,
            });
            await _context.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateClass(ClassDTO classDto)
        {
            Class c = await _context.Classes.FirstOrDefaultAsync(c => c.Id.Equals(classDto.Id));
            if (c == null)
            {
                return false;
            }
            c.Name = classDto.Name;
            c.SemesterId = classDto.SemesterId;
            c.Level = classDto.Level;
            c.Subject = classDto.Subject;
            c.StartDate = classDto.StartDate;
            c.EndDate = classDto.EndDate;
            c.TeacherId = classDto.TeacherId;
            c.Shift = classDto.Shift;
            c.Room = classDto.Room;
            c.Room_addons = classDto.Room_addons;
            c.TuitionMoney = classDto.TuitionMoney;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddStudentIntoClass(string studentId, string classId)
        {
            try
            {
                _context.StudentClassDetails.AddAsync(new StudentClassDetail
                {
                    ClassId = classId,
                    StudentId = studentId,
                    Grade01 = 0.0,
                    Grade02 = 0.0,
                    Grade03 = 0.0,
                    Grade04 = 0.0,
                    Bonus = 0.0,
                    GradeTotal = 0.0,
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
