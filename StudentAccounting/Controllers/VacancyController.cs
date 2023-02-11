using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacanciesService _vacanciesService;
        public VacancyController(IVacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }
        [Authorize]
        [HttpGet("GetVacancy")]
        public ActionResult<IEnumerable<Vacancy>> Get()
        {
            try
            {
                return Ok(_vacanciesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("GetVacancyForStagesId")]
        public ActionResult<IEnumerable<Vacancy>> GetForStagesId(int stagesId)
        {
            try
            {
                return Ok(_vacanciesService.GetForStagesId(stagesId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetVacancyPosition")]
        public ActionResult<IEnumerable<Vacancy>> GetVacanciesPos(int participantsId)
        {
            try
            {
                return Ok(_vacanciesService.Get(participantsId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idVacancy/{id}", Name = "GetVacancyId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_vacanciesService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameVacancy/{name}", Name = "GetVacancyName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_vacanciesService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpPost("CreateVacancy")]
        public IActionResult Create(Vacancy vacancy)
        {
            try
            {
                _vacanciesService.Create(vacancy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpPut("UpdateVacancy")]
        public IActionResult Update(Vacancy vacancy)
        {
            try
            {
                _vacanciesService.Edit(vacancy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpDelete("DeleteVacancy")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vacanciesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
