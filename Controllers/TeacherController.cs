using Course_System.DTOs;
using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachers();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(string id)
        {
            var teacher = await _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTeachersByName([FromQuery] string name)
        {
            var teachers = await _teacherService.GetTeachersByName(name);
            return Ok(teachers);
        }

        [HttpGet("{id}/contract-status")]
        public async Task<IActionResult> GetTeacherContractStatus(string id)
        {
            var contractStatus = await _teacherService.GetTeacherContractStatus(id);
            if (contractStatus == null)
            {
                return NotFound();
            }
            return Ok(contractStatus);
        }
    }
}
