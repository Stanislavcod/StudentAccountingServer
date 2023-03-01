using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    public class ApplicationInTheProjectController : Controller
    {
        private readonly ILogger<ApplicationInTheProjectController> _logger;
        private readonly IApplicationInTheProjectService _applicationInTheProjectService;

        public ApplicationInTheProjectController(IApplicationInTheProjectService applicationInTheProjectService, ILogger<ApplicationInTheProjectController> logger)
        {
            _logger = logger;
            _applicationInTheProjectService = applicationInTheProjectService;
        }
        
        [Authorize]
        [HttpGet("GetAppInTheProject")]
        public ActionResult<IEnumerable<ApplicationsInTheProject>> Get()
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpPut("GetAppInTheProjectForVacancyId")]
        public ActionResult<IEnumerable<ApplicationsInTheProject>> GetForVacancyId(int vacancyId)
        {
            try
            {
                return Ok(_applicationInTheProjectService.GetForVacancyId(vacancyId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("idAppInTheProject/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm,LocalPm,User")]
        [HttpPost("CreateAppInTheProject")]
        public IActionResult Create(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Create(applicationsInTheProject);
                
                _logger.LogInformation($"{DateTime.Now}: Create new applicationsInTheProject");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,GlobalPm,LocalPm")]
        [HttpPut("UpdateAppInTheProject")]
        public IActionResult Update(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Edit(applicationsInTheProject);
                
                _logger.LogInformation($"{DateTime.Now}: Edit applicationsInTheProject with {applicationsInTheProject.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteAppInTheProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _applicationInTheProjectService.Delete(id);
                
                _logger.LogInformation($"{DateTime.Now}: Delete applicationsInTheProject with {id}");
                
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
