using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    public class StagesOfProjectController : Controller
    {
        private readonly IStagesOfProjectsService _stagesOfProjectsService;
        public StagesOfProjectController(IStagesOfProjectsService stagesOfProjectsService)
        {
            _stagesOfProjectsService = stagesOfProjectsService;
        }
        [Authorize]
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
        [Authorize]
        [HttpPut("GetStagesOfProjectForProjectId")]
        public ActionResult<IEnumerable<StagesOfProject>> GetForProjectId(int projectId)
        {
            try
            {
                return Ok(_stagesOfProjectsService.GetForProjectId(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
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
        [Authorize]
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
        [Authorize(Roles = "Admin,GlobalPm")]
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
        [Authorize(Roles = "Admin,GlobalPm")]
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
        [Authorize(Roles = "Admin,GlobalPm")]
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
