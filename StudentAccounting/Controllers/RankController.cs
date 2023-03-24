using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RankController : Controller
    {
        private readonly IRankService _rankService;
        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }
        [Authorize]
        [HttpGet("GetRank")]
        public ActionResult<IEnumerable<Rank>> Get()
        {
            try
            {
                return Ok(_rankService.Get());
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
                return Ok(_rankService.Get(id));
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
                return Ok(_rankService.Get(name));
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
                _rankService.Create(Rank);
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
                _rankService.Edit(Rank);
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
                _rankService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetFiltredRanks")]
        public IActionResult GetFiltredRanks(RankFilter filter)
        {
            try
            {
                _rankService.GetFiltredRanks(filter);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
