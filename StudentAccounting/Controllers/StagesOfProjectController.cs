using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class StagesOfProjectController : Controller
    {
        private readonly IStagesOfProjectsService _stagesOfProjectsService;
        public StagesOfProjectController(IStagesOfProjectsService stagesOfProjectsService)
        {
            _stagesOfProjectsService = stagesOfProjectsService;
        }
        [HttpGet("GetStagesOfProject")]
        public ActionResult<IEnumerable<StagesOfProject>> Get()
        {
            return Ok(_stagesOfProjectsService.Get());
        }
        [HttpGet("idStagesOfProject/{id}", Name = "GetStagesOfProjectId")]
        public IActionResult Get(int id)
        {
            return Ok(_stagesOfProjectsService.Get(id));
        }
        [HttpGet("nameStagesOfProject/{name}", Name = "GetStagesOfProjectName")]
        public IActionResult Get(string name)
        {
            return Ok(_stagesOfProjectsService.Get(name));
        }
        [HttpPost("CreateStagesOfProject")]
        public IActionResult Create(StagesOfProject stagesOfProject)
        {
            _stagesOfProjectsService.Create(stagesOfProject);
            return Ok();
        }
        [HttpPut("UpdateStagesOfProject")]
        public IActionResult Update(StagesOfProject stagesOfProject)
        {
            _stagesOfProjectsService.Edit(stagesOfProject);
            return Ok();
        }
        [HttpDelete("DeleteStagesOfProject")]
        public IActionResult Delete(int id)
        {
            _stagesOfProjectsService.Delete(id);
            return Ok();
        }
    }
}
