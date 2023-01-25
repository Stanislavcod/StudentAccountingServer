using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

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
        public ActionResult<IEnumerable<Participants>> Get()
        {
            return Ok(_participantsService.Get());
        }
        [HttpGet("idParticipant/{id}", Name ="GetPartisipantsId")]
        public IActionResult Get(int id)
        {
            return Ok(_participantsService.Get(id));
        }
        [HttpPost("CreateParticipant")]
        public IActionResult Create(Participants participants)
        {
            _participantsService.Create(participants);
            return Ok();
        }
        [HttpPut("UpdateParticipant")]
        public IActionResult Update(Participants participants)
        {
            _participantsService.Edit(participants);
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
