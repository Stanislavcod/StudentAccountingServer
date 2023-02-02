using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    [Authorize]
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
            try
            {
                return Ok(_stagesOfProjectsService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idStagesOfProject/{id}", Name = "GetStagesOfProjectId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_stagesOfProjectsService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameStagesOfProject/{name}", Name = "GetStagesOfProjectName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_stagesOfProjectsService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateStagesOfProject")]
        public IActionResult Create(StagesOfProject stagesOfProject)
        {
            try
            {
                _stagesOfProjectsService.Create(stagesOfProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateStagesOfProject")]
        public IActionResult Update(StagesOfProject stagesOfProject)
        {
            try
            {
                _stagesOfProjectsService.Edit(stagesOfProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteStagesOfProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _stagesOfProjectsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
