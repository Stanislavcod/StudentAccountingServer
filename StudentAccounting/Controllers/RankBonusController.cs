using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RankBonusController : Controller
    {
        private readonly IRankBonusService _rankBonusService;
        public RankBonusController(IRankBonusService rankBonusService)
        {
            _rankBonusService = rankBonusService;
        }

        [Authorize]
        [HttpGet("GetRankBonus")]
        public ActionResult<IEnumerable<RankBonus>> Get()
        {
            try
            {
                return Ok(_rankBonusService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idRankBonus/{id}", Name = "GetRankBonusId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_rankBonusService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRankBonus")]
        public IActionResult Create(RankBonus rankBonus)
        {
            try
            {
                _rankBonusService.Create(rankBonus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRankBonus")]
        public IActionResult Update(RankBonus rankBonus)
        {
            try
            {
                _rankBonusService.Edit(rankBonus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteRankBonus")]
        public IActionResult Delete(int id)
        {
            try
            {
                _rankBonusService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

