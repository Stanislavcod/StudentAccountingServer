using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Implementations;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RangController : Controller
    {
        private readonly IRangService _routingService;
        public RangController(IRangService routingService)
        {
            _routingService = routingService;
        }

        [HttpGet("GetRang")]
        public ActionResult<IEnumerable<Rang>> Get()
        {
            return Ok(_routingService.Get());
        }
        [HttpGet("idRang/{id}", Name = "GetRangId")]
        public IActionResult Get(int id)
        {
            return Ok(_routingService.Get(id));
        }
        [HttpGet("nameRang/{name}", Name = "GetRangName")]
        public IActionResult Get(string name)
        {
            return Ok(_routingService.Get(name));
        }
        [HttpPost("CreateRang")]
        public IActionResult Create(Rang rang)
        {
            _routingService.Create(rang);
            return Ok();
        }
        [HttpPut("UpdateRang")]
        public IActionResult Update(Rang rang)
        {
            _routingService.Edit(rang);
            return Ok();
        }
        [HttpDelete("DeleteRang")]
        public IActionResult Delete(int id)
        {
             _routingService.Delete(id);
            return Ok();
        }
    }
}
