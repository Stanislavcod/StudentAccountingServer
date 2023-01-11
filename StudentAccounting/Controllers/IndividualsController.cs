using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.Controllers
{
    public class IndividualsController : Controller
    {
        private readonly IIndividualsService _individualsService;
        public IndividualsController(IIndividualsService individualsService)
        {
            _individualsService = individualsService;
        }
        [HttpGet("GetIndividuals")]
        public ActionResult<IEnumerable<IndividualsDto>> Get()
        {
            return Ok(_individualsService.Get());
        }
        [HttpGet("nameIndividual/{name}", Name ="GetIndividualName")]
        public IActionResult Get(string name)
        {
            return Ok(_individualsService.Get(name));
        }
        [HttpGet("idIndividual/{id}", Name ="GetIndividualId")]
        public IActionResult Get(int id)
        {
            return Ok(_individualsService.Get(id));
        }
        [HttpPost("CreateIndividual")]
        public IActionResult Create(IndividualsDto newIndividuals)
        {
            _individualsService.Create(newIndividuals);
            return Ok();
        }
        [HttpPut("UpdateIndividual")]
        public IActionResult Update(IndividualsDto newIndividuals)
        {
            _individualsService.Edit(newIndividuals);
            return Ok();
        }
        [HttpDelete("DeletIndividual")]
        public IActionResult Delete(int id)
        {
            _individualsService.Delete(id);
            return Ok();
        }
    }
}
