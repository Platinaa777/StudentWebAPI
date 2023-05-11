using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Repository;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService context;

        public StudentController(IStudentService context) 
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var studentsList =  await context.GetStudents();
            return Ok(studentsList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await context.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student student)
        {
            var studentsList = await context.CreateStudent(student);

            return Ok(studentsList);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var studentsLIst = await context.DeleteStudent(id);
            if (studentsLIst == null)
            {
                return NotFound();
            }
            return Ok(studentsLIst);
        }

        [HttpGet("{name}/{lastname}")]
        public async Task<ActionResult<Student>> GetStudentByNameAndLastName(string name, string lastname)
        {
            var student = await context.GetStudentByNameAndLastName(name, lastname);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            var newStudent = await context.UpdateStudent(student);
            if (newStudent == null)
            {
                return NotFound();
            }
            return Ok(newStudent);
        }
    }
}
