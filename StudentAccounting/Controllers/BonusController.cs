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
            return Ok(_bonusService.Get());
        }
        [HttpGet("idBonus/{id}", Name = "GetBonusId")]
        public IActionResult Get(int id)
        {
            return Ok(_bonusService.Get(id));
        }
        [HttpGet("nameBonus/{name}", Name = "GetRankBonus")]
        public IActionResult Get(string name)
        {
            return Ok(_bonusService.Get(name));
        }
        [HttpPost("CreateBonus")]
        public IActionResult Create(Bonus bonus)
        {
            _bonusService.Create(bonus);
            return Ok();
        }
        [HttpPut("UpdateBonus")]
        public IActionResult Update(Bonus bonus)
        {
            _bonusService.Edit(bonus);
            return Ok();
        }
        [HttpDelete("DeleteBonus")]
        public IActionResult Delete(int id)
        {
            _bonusService.Delete(id);
            return Ok();
        }
    }
}
