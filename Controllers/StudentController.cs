using Course_System.DTOs;
using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStudentsByName([FromQuery] string name)
        {
            var students = await _studentService.GetStudentsByName(name);
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDTO student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var result = await _studentService.AddStudent(student);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{id}/classes")]
        public async Task<IActionResult> GetClassesOfStudent(string id)
        {
            var classes = await _studentService.GetClassesOfStudent(id);
            return Ok(classes);
        }
    }
}
