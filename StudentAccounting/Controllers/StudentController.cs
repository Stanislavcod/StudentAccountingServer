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
            try
            {
                return Ok(_studentService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idStudent/{id}", Name = "GetStudentId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_studentService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateStudent")]
        public IActionResult Create(Student student)
        {
            try
            {
                _studentService.Create(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateStudent")]
        public IActionResult Update(Student student)
        {
            try
            {
                _studentService.Edit(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("StudentByIndividuals")]
        public IActionResult StudentByIndividuals(int individualsId)
        {
            try
            {
                return Ok(_studentService.GetByIndividuals(individualsId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
