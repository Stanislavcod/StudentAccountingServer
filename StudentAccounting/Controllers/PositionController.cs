using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet("GetPosition")]
        public ActionResult<IEnumerable<Position>> Get()
        {
            return Ok(_positionService.Get());
        }
        [HttpGet("idPosition/{id}", Name = "GetPositionId")]
        public IActionResult Get(int id)
        {
            return Ok(_positionService.Get(id));
        }
        [HttpGet("namePosition/{name}", Name = "GetPositionName")]
        public IActionResult Get(string name)
        {
            return Ok(_positionService.Get(name));
        }
        [HttpPost("CreatePosition")]
        public IActionResult Create(Position position)
        {
            _positionService.Create(position);
            return Ok();
        }
        [HttpPut("UpdatePosition")]
        public IActionResult Update(Position position)
        {
            _positionService.Edit(position);
            return Ok();
        }
        [HttpDelete("DeletePosition")]
        public IActionResult Delete(int id)
        {
            _positionService.Delete(id);
            return Ok();
        }
    }
}
