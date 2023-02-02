using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    [Authorize]
    public class IndividualsController : Controller
    {
        private readonly IIndividualsService _individualsService;
        public IndividualsController(IIndividualsService individualsService)
        {
            _individualsService = individualsService;
        }
        [HttpGet("GetIndividuals")]
        public ActionResult<IEnumerable<Individuals>> Get()
        {
            try
            {
                return Ok(_individualsService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameIndividual/{name}", Name = "GetIndividualName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_individualsService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idIndividual/{id}", Name = "GetIndividualId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_individualsService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateIndividual")]
        public IActionResult Create(Individuals newIndividuals)
        {
            try
            {
                _individualsService.Create(newIndividuals);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateIndividual")]
        public IActionResult Update(Individuals newIndividuals)
        {
            try
            {
                _individualsService.Edit(newIndividuals);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletIndividual")]
        public IActionResult Delete(int id)
        {
            try
            {
                _individualsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
