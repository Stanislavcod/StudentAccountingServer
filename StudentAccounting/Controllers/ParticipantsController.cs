using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    [Authorize]
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
            try
            {
                return Ok(_participantsService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idParticipant/{id}", Name = "GetPartisipantsId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_participantsService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateParticipant")]
        public IActionResult Create(Participants participants)
        {
            try
            {
                _participantsService.Create(participants);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateParticipant")]
        public IActionResult Update(Participants participants)
        {
            try
            {
                _participantsService.Edit(participants);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteParticipant")]
        public IActionResult Delete(int id)
        {
            try
            {
                _participantsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ParticipantByUser")]
        public IActionResult GetByUser(int userId)
        {
            try
            {
                return Ok(_participantsService.GetByUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
