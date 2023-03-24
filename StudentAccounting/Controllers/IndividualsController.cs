using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class IndividualsController : Controller
    {
        private readonly ILogger<IndividualsController> _logger;
        private readonly IIndividualsService _individualsService;
        
        public IndividualsController(IIndividualsService individualsService, ILogger<IndividualsController> logger)
        {
            _logger = logger;
            _individualsService = individualsService;
        }
        
        [Authorize]
        [HttpGet("GetIndividuals")]
        public ActionResult<IEnumerable<Individuals>> Get()
        {
            try
            {
                return Ok(_individualsService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("nameIndividual/{name}", Name = "GetIndividualName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_individualsService.Get(name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("idIndividual/{id}", Name = "GetIndividualId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_individualsService.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPost("CreateIndividual")]
        public IActionResult Create(Individuals newIndividuals)
        {
            try
            {
                _individualsService.Create(newIndividuals);
                
                _logger.LogInformation($"{DateTime.Now}: Create new individuals");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPut("UpdateIndividual")]
        public IActionResult Update(Individuals newIndividuals)
        {
            try
            {
                _individualsService.Edit(newIndividuals);
                
                _logger.LogInformation($"{DateTime.Now}: Edit bonus with {newIndividuals.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteIndividual")]
        public IActionResult Delete(int id)
        {
            try
            {
                _individualsService.Delete(id);
                
                _logger.LogInformation($"{DateTime.Now}: Delete individuals with {id}");
                
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
