using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTO;
using School_Management_System.Interfaces.Service;
using School_Management_System.Models;
using School_Management_System.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService _studentService)
        {
            studentService = _studentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> Get()
        {
            try
            {
                var studentList =  await studentService.GetAllStudents();
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> Get(int id)
        {
            
            try
            {
                var student = await studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync(StudentDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }

                 await studentService.AddStudent(value);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, StudentDTO value)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }
                var existingStudent = await studentService.GetStudentById(id);
                if (existingStudent == null)
                {
                    return NotFound(); // Return HTTP 404 if the student does not exist
                }
                await studentService.UpdateStudent(id, value);
                return CreatedAtAction(nameof(Get), new { id = id }, value);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }
                var existingStudent = await studentService.GetStudentById(id);
                if (existingStudent == null)
                {
                    return NotFound(); // Return HTTP 404 if the student does not exist
                }
                await studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.ToString());
            }
        }
    }
}
