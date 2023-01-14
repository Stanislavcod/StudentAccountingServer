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
        [HttpGet("GetProject")]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return Ok(_projectService.Get());
        }
        [HttpGet("idProject/{id}", Name = "GetProjectId")]
        public IActionResult Get(int id)
        {
            return Ok(_projectService.Get(id));
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(Project project)
        {
            _projectService.Create(project);
            return Ok();
        }
        [HttpPut("UpdateProject")]
        public IActionResult Update(Project project)
        {
            _projectService.Edit(project);
            return Ok();
        }
        [HttpDelete("DeleteProject")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Ok();
        }
    }
}
