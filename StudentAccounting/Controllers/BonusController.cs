using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class BonusController : Controller
    {
        private readonly IBonusService _bonusService;
        public BonusController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpGet("GetBonus")]
        public ActionResult<IEnumerable<Bonus>> Get()
        {
            try
            {
                return Ok(_bonusService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("idBonus/{id}", Name = "GetBonusId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_bonusService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("nameBonus/{name}", Name = "GetBonusName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_bonusService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("CreateBonus")]
        public IActionResult Create(Bonus bonus)
        {
            try
            {
                _bonusService.Create(bonus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("UpdateBonus")]
        public IActionResult Update(Bonus bonus)
        {
            try
            {
                _bonusService.Edit(bonus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("DeleteBonus")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bonusService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("BonusForRankId/{id}", Name = "GetBonusForRankId")]
        public IActionResult GetForRank(int id)
        {
            try
            {
                return Ok(_bonusService.GetForRank(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
