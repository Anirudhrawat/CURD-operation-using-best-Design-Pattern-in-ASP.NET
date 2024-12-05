using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTO;
using School_Management_System.Interfaces.Service;
using School_Management_System.Service;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService enrollmentService;
        public EnrollmentsController(IEnrollmentService _enrollmentService)
        {
            enrollmentService = _enrollmentService;
        }
        // GET api/<EnrollmentsController>/5
        // GET api/<EnrollmentsController>/5
        [HttpGet("student/{id}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetCourse(int id)
        {
            try
            {
                var list = await enrollmentService.GetEnrollmentsByCourse(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.ToString());
            }
        }

        // GET api/<EnrollmentsController>/5
        [HttpGet("course/{id}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetStudents(int id)
        {
            try
            {
                var list = await enrollmentService.GetEnrollmentsByStudent(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetAsync([FromQuery] int cid, [FromQuery]  int sid)
        {
            try
            {
                await enrollmentService.EnrollStudent(sid,cid);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.ToString());
            }
        }
    }
}
