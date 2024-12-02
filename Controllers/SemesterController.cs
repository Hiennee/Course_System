using Course_System.DTOs;
using Course_System.Models;
using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly SemesterService _semesterService;

        public SemesterController(SemesterService semesterService)
        {
            _semesterService = semesterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSemesters()
        {
            var semesters = await _semesterService.GetAllSemesters();
            return Ok(semesters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSemesterById(string id)
        {
            var semester = await _semesterService.GetSemesterById(id);
            if (semester == null)
            {
                return NotFound(new { message = $"Semester with ID {id} not found." });
            }
            return Ok(semester);
        }

        [HttpGet("{id}/classes")]
        public async Task<IActionResult> GetClassesInSemester(string id)
        {
            var classes = await _semesterService.GetClassesInSemester(id);
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSemester([FromBody] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { message = "Semester ID cannot be null or empty." });
            }

            var result = await _semesterService.AddSemester(id);
            if (!result)
            {
                return StatusCode(500, new { message = "An error occurred while adding the semester." });
            }

            return Ok(new { message = "Semester added successfully." });
        }
    }
}
