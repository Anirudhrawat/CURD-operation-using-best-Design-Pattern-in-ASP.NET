using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Management_System.DTO;
using School_Management_System.Interfaces.Service;
using School_Management_System.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CoursesController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> Get()
        {
            try
            {
                var studentList = await courseService.GetAllCourses();
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> Get(int id)
        {
            try
            {
                var course = await courseService.GetCourseById(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult> Post(CourseDTO course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }

                await courseService.AddCourse(course);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CourseDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }
                var existingCourse = await courseService.GetCourseById(id);
                if (existingCourse == null)
                {
                    return NotFound(); // Return HTTP 404 if the student does not exist
                }
                await courseService.UpdateCourse(id, value);
                return CreatedAtAction(nameof(Get), new { id = id }, value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return HTTP 400 if model validation fails
                }
                var existingStudent = await courseService.GetCourseById(id);
                if (existingStudent == null)
                {
                    return NotFound(); // Return HTTP 404 if the student does not exist
                }
                await courseService.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.ToString());
            }
        }
    }
}
