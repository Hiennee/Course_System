using Course_System.DTOs;
using Course_System.Models;
using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _courseService.GetAllClasses();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(string id)
        {
            var course = await _courseService.GetClassById(id);
            if (course == null)
            {
                return NotFound(new { message = $"Class with ID {id} not found." });
            }
            return Ok(course);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetClassesByName([FromQuery] string name)
        {
            var courses = await _courseService.GetClassesByName(name);
            return Ok(courses);
        }

        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetAllStudentsInClass(string id)
        {
            var students = await _courseService.GetAllStudentsInClass(id);
            return Ok(students);
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult> GetClassesOfTeacher(string teacherId)
        {
            var courses = await _courseService.GetClassesOfTeacher(teacherId);
            return Ok(courses);
        }

        [HttpGet("{id}/tuition")]
        public async Task<IActionResult> GetClassTuition(string id)
        {
            var tuition = await _courseService.GetClassTuition(id);
            return Ok(new { ClassId = id, Tuition = tuition });
        }

        [HttpPost]
        public async Task<IActionResult> InsertClass([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest(new { message = "Invalid class data." });
            }

            var result = await _courseService.InsertClass(course);
            if (!result)
            {
                return StatusCode(500, new { message = "An error occurred while adding the class." });
            }

            return Ok(new { message = "Class added successfully." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass([FromBody] CourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new { message = "Invalid class data." });
            }

            var result = await _courseService.UpdateClass(courseDto);
            if (!result)
            {
                return NotFound(new { message = $"Class with ID {courseDto.Id} not found." });
            }

            return Ok(new { message = "Class updated successfully." });
        }

        [HttpPost("{id}/students")]
        public async Task<IActionResult> AddStudentIntoClass(string id, [FromBody] string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                return BadRequest();
            }

            var result = await _courseService.AddStudentIntoClass(studentId, id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(new { message = "Student added to the class successfully." });
        }
    }
}
