using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    [Authorize]
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
            try
            {
                return Ok(_regulationsService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idRegulation/{id}", Name = "GetRegulationId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_regulationsService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameRegulation/{name}", Name = "GetRegulationName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_regulationsService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateRegulation")]
        public IActionResult Create(Regulation regulation)
        {
            try
            {
                _regulationsService.Create(regulation);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateRegulation")]
        public IActionResult Update(Regulation regulation)
        {
            try
            {
                _regulationsService.Edit(regulation);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteRegulation")]
        public IActionResult Delete(int id)
        {
            try
            {
                _regulationsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
