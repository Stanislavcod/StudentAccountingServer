using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetStudents")]
        public ActionResult<IEnumerable<StudentDto>> Get()
        {
            return Ok(_studentService.Get());
        }
        [HttpGet("idStudent/{id}", Name ="GetStudentId")]
        public IActionResult Get(int id)
        {
            return Ok(_studentService.Get(id));
        }
        [HttpPost("CreateStudent")]
        public IActionResult Create(StudentDto studentDto)
        {
            _studentService.Create(studentDto);
            return Ok();
        }
        [HttpPut("UpdateStudent")]
        public IActionResult Update(StudentDto studentDto)
        {
            _studentService.Edit(studentDto);
            return Ok();
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return Ok();
        }
    }
}
