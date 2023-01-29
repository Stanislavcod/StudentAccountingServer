using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("GetDepartment")]

        public ActionResult<IEnumerable<Department>> Get()
        {
            try
            {
                return Ok(_departmentService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idDepartment/{id}", Name = "GetDepartmentId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_departmentService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameDepartment/{name}", Name = "GetDepartmentName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_departmentService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateDepartment")]
        public IActionResult Create(Department department)
        {
            try
            {
                _departmentService.Create(department);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateDepartment")]
        public IActionResult Update(Department department)
        {
            try
            {
                _departmentService.Edit(department);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete(int id)
        {
            try
            {
                _departmentService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
