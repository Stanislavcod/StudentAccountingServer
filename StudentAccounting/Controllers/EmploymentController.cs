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
            try
            {
                return Ok(_employmentService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idEmployment/{id}", Name = "GetEmploymentId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_employmentService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateEmployment")]
        public IActionResult Create(Employment employment)
        {
            try
            {
                _employmentService.Create(employment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateEmployment")]
        public IActionResult Update(Employment employment)
        {
            try
            {
                _employmentService.Edit(employment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteEmployment")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employmentService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
