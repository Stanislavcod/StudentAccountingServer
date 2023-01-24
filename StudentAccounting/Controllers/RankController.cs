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

        [HttpGet("GetRank")]
        public ActionResult<IEnumerable<Rank>> Get()
        {
            return Ok(_routingService.Get());
        }
        [HttpGet("idRank/{id}", Name = "GetRankId")]
        public IActionResult Get(int id)
        {
            return Ok(_routingService.Get(id));
        }
        [HttpGet("nameRank/{name}", Name = "GetRankName")]
        public IActionResult Get(string name)
        {
            return Ok(_routingService.Get(name));
        }
        [HttpPost("CreateRank")]
        public IActionResult Create(Rank Rank)
        {
            _routingService.Create(Rank);
            return Ok();
        }
        [HttpPut("UpdateRank")]
        public IActionResult Update(Rank Rank)
        {
            _routingService.Edit(Rank);
            return Ok();
        }
        [HttpDelete("DeleteRank")]
        public IActionResult Delete(int id)
        {
             _routingService.Delete(id);
            return Ok();
        }
    }
}
