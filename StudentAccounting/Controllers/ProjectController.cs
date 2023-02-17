using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [Authorize]
        [HttpGet("GetProject")]
        public ActionResult<IEnumerable<Project>> Get()
        {
            try
            {
                return Ok(_projectService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetProjectForParticipantId")]
        public ActionResult<List<Project>> GetForParticipantId(int participantsId)
        {
            try
            {
                return Ok(_projectService.GetForParticipantsId(participantsId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idProject/{id}", Name = "GetProjectId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_projectService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpPost("CreateProject")]
        public IActionResult Create(Project project)
        {
            try
            {
                _projectService.Create(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm,LocalPm")]
        [HttpPut("UpdateProject")]
        public IActionResult Update(Project project)
        {
            try
            {
                _projectService.Edit(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _projectService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
