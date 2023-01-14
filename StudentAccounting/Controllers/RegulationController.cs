using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RegulationController : Controller
    {
       private readonly IRegulationsService _regulationsService;
        public RegulationController(IRegulationsService regulationsService)
        {
            _regulationsService = regulationsService;
        }
        [HttpGet("GetRegulation")]
        public ActionResult<IEnumerable<Regulation>> Get()
        {
            return Ok(_regulationsService.Get());
        }
        [HttpGet("idRegulation/{id}", Name = "GetRegulationId")]
        public IActionResult Get(int id)
        {
            return Ok(_regulationsService.Get(id));
        }
        [HttpGet("nameRegulation/{name}", Name = "GetRegulationName")]
        public IActionResult Get(string name)
        {
            return Ok(_regulationsService.Get(name));
        }
        [HttpPost("CreateRegulation")]
        public IActionResult Create(Regulation regulation)
        {
            _regulationsService.Create(regulation);
            return Ok();
        }
        [HttpPut("UpdateRegulation")]
        public IActionResult Update(Regulation regulation)
        {
            _regulationsService.Edit(regulation);
            return Ok();
        }
        [HttpDelete("DeleteRegulation")]
        public IActionResult Delete(int id)
        {
            _regulationsService.Delete(id);
            return Ok();
        }
    }
}
