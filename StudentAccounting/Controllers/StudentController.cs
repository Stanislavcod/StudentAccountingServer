using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

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
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_studentService.Get());
        }
        [HttpGet("idStudent/{id}", Name ="GetStudentId")]
        public IActionResult Get(int id)
        {
            return Ok(_studentService.Get(id));
        }
        [HttpPost("CreateStudent")]
        public IActionResult Create(Student student)
        {
            _studentService.Create(student);
            return Ok();
        }
        [HttpPut("UpdateStudent")]
        public IActionResult Update(Student student)
        {
            _studentService.Edit(student);
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
