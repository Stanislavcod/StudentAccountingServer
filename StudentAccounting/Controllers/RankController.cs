using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RankController : Controller
    {
        private readonly IRankService _routingService;
        public RankController(IRankService routingService)
        {
            _routingService = routingService;
        }
        [Authorize]
        [HttpGet("GetRank")]
        public ActionResult<IEnumerable<Rank>> Get()
        {
            try
            {
                return Ok(_routingService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idRank/{id}", Name = "GetRankId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_routingService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameRank/{name}", Name = "GetRankName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_routingService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRank")]
        public IActionResult Create(Rank Rank)
        {
            try
            {
                _routingService.Create(Rank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRank")]
        public IActionResult Update(Rank Rank)
        {
            try
            {
                _routingService.Edit(Rank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteRank")]
        public IActionResult Delete(int id)
        {
            try
            {
                _routingService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
