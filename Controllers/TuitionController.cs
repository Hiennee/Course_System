using Course_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Course_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionController : ControllerBase
    {
        private readonly TuitionService _tuitionService;

        public TuitionController(TuitionService tuitionService)
        {
            _tuitionService = tuitionService;
        }

        [HttpGet("{studentId}/{semesterId}")]
        public async Task<IActionResult> GetStudentTuitionInfo(string studentId, string semesterId)
        {
            var tuition = await _tuitionService.GetStudentTuitionInfo(studentId, semesterId);
            if (tuition == 0)
            {
                return NotFound();
            }
            return Ok(tuition);
        }

        [HttpGet("{studentId}/{semesterId}/due")]
        public async Task<IActionResult> GetStudentTuitionDue(string studentId, string semesterId)
        {
            var dueDate = await _tuitionService.GetStudentTuitionDue(studentId, semesterId);
            if (dueDate == default)
            {
                return NotFound();
            }
            return Ok(dueDate);
        }
    }
}
