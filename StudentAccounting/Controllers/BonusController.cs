using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class BonusController : Controller
    {
        private readonly ILogger<BonusController> _logger;
        private readonly IBonusService _bonusService;
        
        public BonusController(IBonusService bonusService, ILogger<BonusController> logger)
        {
            _logger = logger;
            _bonusService = bonusService;
        }
        
        [Authorize]
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
        
        [Authorize]
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
        
        [Authorize]
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
        
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateBonus")]
        public IActionResult Create(Bonus bonus)
        {
            try
            {
                _bonusService.Create(bonus);
                
                _logger.LogInformation($"{DateTime.Now}: Create new bonus");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBonus")]
        public IActionResult Update(Bonus bonus)
        {
            try
            {
                _bonusService.Edit(bonus);
                
                _logger.LogInformation($"{DateTime.Now}: Edit bonus with {bonus.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBonus")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bonusService.Delete(id);
                
                _logger.LogInformation($"{DateTime.Now}: Delete bonus with {id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpPut("GetBonusForRankId")]
        public IActionResult GetForRank(int id)
        {
            try
            {
                return Ok(_bonusService.GetForRank(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
    }
}
