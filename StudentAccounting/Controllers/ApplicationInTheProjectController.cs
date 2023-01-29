using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    public class ApplicationInTheProjectController : Controller
    {
        private readonly IApplicationInTheProjectService _applicationInTheProjectService;

        public ApplicationInTheProjectController(IApplicationInTheProjectService applicationInTheProjectService)
        {
            _applicationInTheProjectService = applicationInTheProjectService;
        }

        [HttpGet("GetAppInTheProject")]
        public ActionResult<IEnumerable<ApplicationsInTheProject>> Get()
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idAppInTheProject/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get(id));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateAppInTheProject")]
        public IActionResult Create(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Create(applicationsInTheProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateAppInTheProject")]
        public IActionResult Update(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Edit(applicationsInTheProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteAppInTheProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _applicationInTheProjectService.Delete(id);
                return Ok();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
