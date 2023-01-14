using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class DepartamentController : Controller
    {
        private readonly IDepartamentService _departamentService;
        public DepartamentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }
        [HttpGet("GetDepartment")]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return Ok(_departamentService.Get());
        }
        [HttpGet("idDepartment/{id}", Name = "GetDepartmentId")]
        public IActionResult Get(int id)
        {
            return Ok(_departamentService.Get(id));
        }
        [HttpGet("nameDepartment/{name}", Name = "GetDepartmentName")]
        public IActionResult Get(string name)
        {
            return Ok(_departamentService.Get(name));
        }
        [HttpPost("CreateDepartment")]
        public IActionResult Create(Department departament)
        {
            _departamentService.Create(departament);
            return Ok();
        }
        [HttpPut("UpdateDepartment")]
        public IActionResult Update(Department department)
        {
            _departamentService.Edit(department);
            return Ok();
        }
        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete(int id)
        {
            _departamentService.Delete(id);
            return Ok();
        }
    }
}
