using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        [HttpGet("FIOParticipant/{FIO}", Name = "GetParticipantByIndividualFIO")]
        public IActionResult GetByIndividualsFIO(string name)
        {
            try
            {
                return Ok(_participantsService.GetByIndividualName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize]
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
