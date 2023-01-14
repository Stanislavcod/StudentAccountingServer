using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class EmploymentController : Controller
    {
        private readonly IEmploymentService _employmentService;
        public EmploymentController(IEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }
        [HttpGet("GetEmployments")]
        public ActionResult<IEnumerable<Employment>> Get()
        {
            return Ok(_employmentService.Get());
        }
        [HttpGet("idEmployment/{id}", Name = "GetEmploymentId")]
        public IActionResult Get(int id)
        {
            return Ok(_employmentService.Get(id));
        }
        [HttpPost("CreateEmployment")]
        public IActionResult Create(Employment employment)
        {
            _employmentService.Create(employment);
            return Ok();
        }
        [HttpPut("UpdateEmployment")]
        public IActionResult Update(Employment employment)
        {
            _employmentService.Edit(employment);
            return Ok();
        }
        [HttpDelete("DeleteEmployment")]
        public IActionResult Delete(int id)
        {
            _employmentService.Delete(id);
            return Ok();
        }
    }
}
