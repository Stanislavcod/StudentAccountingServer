using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class EducationalPortalsController : Controller
    {
       private readonly IEducationalPortalsService _educationalPortalsService;
        public EducationalPortalsController(IEducationalPortalsService educationalPortalsService)
        {
            _educationalPortalsService = educationalPortalsService;
        }
        [HttpGet("GetEducationalPortals")]
        public ActionResult<IEnumerable<EducationalPortals>> Get()
        {
            return Ok(_educationalPortalsService.Get());
        }
        [HttpGet("idEducationalPortals/{id}", Name = "GetEducationalPortalsId")]
        public IActionResult Get(int id)
        {
            return Ok(_educationalPortalsService.Get(id));
        }
        [HttpGet("nameEducationalPortals/{name}", Name = "GetEducationalPortals")]
        public IActionResult Get(string name)
        {
            return Ok(_educationalPortalsService.Get(name));
        }
        [HttpPost("CreateEducationalPortals")]
        public IActionResult Create(EducationalPortals educationalPortals)
        {
            _educationalPortalsService.Create(educationalPortals);
            return Ok();
        }
        [HttpPut("UpdateEducationalPortals")]
        public IActionResult Update(EducationalPortals educationalPortals)
        {
            _educationalPortalsService.Edit(educationalPortals);
            return Ok();
        }
        [HttpDelete("DeleteEducationalPortals")]
        public IActionResult Delete(int id)
        {
            _educationalPortalsService.Delete(id);
            return Ok();
        }
    }
}
