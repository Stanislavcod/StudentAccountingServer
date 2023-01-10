using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipantsService _participantsService;
        public ParticipantsController(IParticipantsService participantsService)
        {
            _participantsService = participantsService;
        }
        [HttpGet("GetParticipants")]
        public ActionResult<IEnumerable<ParticipantsDto>> Get()
        {
            return Ok(_participantsService.Get());
        }
        [HttpGet("GetParticipant{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_participantsService.Get(id));
        }
        [HttpPost("CreateParticipant")]
        public IActionResult Create(ParticipantsDto participantsDto)
        {
            _participantsService.Create(participantsDto);
            return Ok();
        }
        [HttpPut("UpdateParticipant")]
        public IActionResult Update(ParticipantsDto participantsDto)
        {
            _participantsService.Edit(participantsDto);
            return Ok();
        }
        [HttpDelete("DeleteParticipant")]
        public IActionResult Delete(int id)
        {
            _participantsService.Delete(id);
            return Ok();
        }
    }
}
