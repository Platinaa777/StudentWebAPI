using Microsoft.AspNetCore.Mvc;
using MyWebAPI.DTOs;
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

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<GetStudentDto>>> GetAllStudents()
        {
            var studentsList =  await context.GetStudents();
            return Ok(studentsList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudent(int id)
        {
            var student = await context.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<List<GetStudentDto>>> CreateStudent(AddStudentDto student)
        {
            var studentsList = await context.CreateStudent(student);

            return Ok(studentsList);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<List<GetStudentDto>>> DeleteStudent(int id)
        {
            var studentsLIst = await context.DeleteStudent(id);
            if (studentsLIst == null)
            {
                return NotFound();
            }
            return Ok(studentsLIst);
        }

        [HttpGet("{name}/{lastname}")]
        public async Task<ActionResult<GetStudentDto>> GetStudentByNameAndLastName(string name, string lastname)
        {
            var student = await context.GetStudentByNameAndLastName(name, lastname);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<GetStudentDto>> UpdateStudent(UpdateStudentDto student)
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
