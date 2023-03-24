using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.Controllers
{
    public class EmploymentController : Controller
    {
        private readonly ILogger<EmploymentController> _logger;
        private readonly IEmploymentService _employmentService;
        
        public EmploymentController(IEmploymentService employmentService, ILogger<EmploymentController> logger)
        {
            _logger = logger;
            _employmentService = employmentService;
        }
        
        [Authorize]
        [HttpGet("GetEmployments")]
        public ActionResult<IEnumerable<Employment>> Get()
        {
            try
            {
                return Ok(_employmentService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("idEmployment/{id}", Name = "GetEmploymentId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_employmentService.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpPost("GetByParticipants")]
        public IActionResult GetByParticipants(int participantsId)
        {
            try
            {
                return Ok(_employmentService.GetByParticipants(participantsId));
            }
            catch(Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpPost("CreateEmployment")]
        public IActionResult Create(Employment employment)
        {
            try
            {
                _employmentService.Create(employment);
                
                _logger.LogInformation($"{DateTime.Now}: Create new employment");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpPut("UpdateEmployment")]
        public IActionResult Update(Employment employment)
        {
            try
            {
                _employmentService.Edit(employment);
                
                _logger.LogInformation($"{DateTime.Now}: Edit employment with {employment.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpDelete("DeleteEmployment")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employmentService.Delete(id);
                
                _logger.LogInformation($"{DateTime.Now}: Delete employment with {id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetFiltredEmployments")]
        public IActionResult GetFiltredEmployments(EmploymentFilter filter)
        {
            try
            {
                _employmentService.GetFiltredEmployments(filter);

                _logger.LogInformation($"{DateTime.Now}: Get departmentFiltered");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return BadRequest(ex.Message);
            }
        }
    }
}
