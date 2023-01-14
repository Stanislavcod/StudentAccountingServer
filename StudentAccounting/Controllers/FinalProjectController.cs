using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class FinalProjectController : Controller
    {
        private readonly IFinalProjectService _finalProjectService;
        public FinalProjectController(IFinalProjectService finalProjectService)
        {
            _finalProjectService = finalProjectService;
        }
        [HttpGet("GetFinalProject")]
        public ActionResult<IEnumerable<FinalProject>> Get()
        {
            return Ok(_finalProjectService.Get());
        }
        [HttpGet("idFinalProject/{id}", Name = "GetFinalProjectId")]
        public IActionResult Get(int id)
        {
            return Ok(_finalProjectService.Get(id));
        }
        [HttpGet("nameFinalProject/{name}", Name = "GetFinalProjectName")]
        public IActionResult Get(string name)
        {
            return Ok(_finalProjectService.Get(name));
        }
        [HttpPost("CreateFinalProject")]
        public IActionResult Create(FinalProject finalProject)
        {
            _finalProjectService.Create(finalProject);
            return Ok();
        }
        [HttpPut("UpdateFinalProject")]
        public IActionResult Update(FinalProject finalProject)
        {
            _finalProjectService.Edit(finalProject);
            return Ok();
        }
        [HttpDelete("DeleteFinalProject")]
        public IActionResult Delete(int id)
        {
            _finalProjectService.Delete(id);
            return Ok();
        }
    }
}
