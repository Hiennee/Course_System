using Course_System.DTOs;
using Course_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_System.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassService _service;
        public ClassController(ClassService service)
        {
            _service = service;
        }
        public async Task<ICollection<ClassDTO>> GetAllClasses()
        {
            return await _service.GetAllClasses();
        }
        public async Task<ICollection<ClassDTO>> GetClassesByName(string className)
        {
            return await _service.GetClassesByName(className);
        }
        public async Task<ClassDTO> GetClassById(string classId)
        {
            return await _service.GetClassById(classId);
        }
        public async Task<ICollection<ClassDTO>> GetClassesOfTeacher(string teacherId)
        {
            return await _service.GetClassesOfTeacher(teacherId);
        }
        public async Task<bool> AddStudentIntoClass(string studentId, string classId)
        {
            return await _service.AddStudentIntoClass(studentId, classId);
        }
        public async Task<double> GetClassTuition(string classId)
        {
            return await _service.GetClassTuition(classId);
        }
        public async Task<ICollection<UserDTO>> GetAllStudentsInClass(string classId)
        {
            return await _service.GetAllStudentsInClass(classId);
        }
        public async Task<bool> UpdateClass(ClassDTO classDto)
        {
            return await _service.UpdateClass(classDto);
        }
    }
}
