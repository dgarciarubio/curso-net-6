using Microsoft.AspNetCore.Mvc;
using MyProject.Api.Models;
using MyProject.Api.Services;
using System.Net;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route($"/{ApiConstants.ApiBase}/{"{version:apiVersion}"}/{ApiConstants.StudentsUri}")]
    [ApiVersion("1.0")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentsService;

        public StudentsController(IStudentService studentService) 
        {
            _studentsService = studentService;
        }

        [HttpGet("", Name = nameof(StudentsController.GetStudents))]
        [ProducesResponseType(typeof(IEnumerable<Student>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStudents()
        {
            var student = _studentsService.GetStudents();

            return Ok(student);
        }

        [HttpGet(ApiConstants.StudentIdParam, Name = nameof(StudentsController.GetStudent))]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetStudent([FromRoute] int studentId) 
        {
            var student = _studentsService.GetStudent(studentId);

            return Ok(student);
        }

        [HttpPut(ApiConstants.StudentIdParam, Name = nameof(StudentsController.UpdateUser))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateUser([FromRoute] int studentId, [FromBody] Student student)
        {
            _studentsService.UpdateStudent(studentId, student.Name);
            return Ok();
        }

        [HttpPost("", Name = nameof(StudentsController.CreateUser))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser([FromBody] Student student)
        {
            var id = _studentsService.CreateStudent(student.Id, student.Name);
            return this.CreatedAtAction(nameof(StudentsController.GetStudent), new { studentId = id }, id);
        }

        [HttpDelete(ApiConstants.StudentIdParam, Name = nameof(StudentsController.RemoveUser))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RemoveUser([FromRoute] int studentId)
        {
            _studentsService.DeleteStudent(studentId);
            return NoContent();
        }
    }
}
