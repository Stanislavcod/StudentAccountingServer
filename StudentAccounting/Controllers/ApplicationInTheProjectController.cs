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
            return Ok(_applicationInTheProjectService.Get());
        }
        [HttpGet("idAppInTheProject/{id}", Name = "GetAppInTheProjectId")]
        public IActionResult Get(int id)
        {
            return Ok(_applicationInTheProjectService.Get(id));
        }
        [HttpPost("CreateAppInTheProject")]
        public IActionResult Create(ApplicationsInTheProject applicationsInTheProject)
        {
            _applicationInTheProjectService.Create(applicationsInTheProject);
            return Ok();
        }
        [HttpPut("UpdateAppInTheProject")]
        public IActionResult Update(ApplicationsInTheProject applicationsInTheProject)
        {
            _applicationInTheProjectService.Edit(applicationsInTheProject);
            return Ok();
        }
        [HttpDelete("DeleteAppInTheProject")]
        public IActionResult Delete(int id)
        {
            _applicationInTheProjectService.Delete(id);
            return Ok();
        }
    }
}
