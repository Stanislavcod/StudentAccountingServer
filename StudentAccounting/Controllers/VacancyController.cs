using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacanciesService _vacanciesService;
        public VacancyController(IVacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }
        [HttpGet("GetVacancy")]
        public ActionResult<IEnumerable<Vacancy>> Get()
        {
            return Ok(_vacanciesService.Get());
        }
        [HttpGet("GetVacancyPosition")]
        public ActionResult<IEnumerable<Vacancy>> Get(Participants participants)
        {
            return Ok(_vacanciesService.Get(participants));
        }
        [HttpGet("idVacancy/{id}", Name = "GetVacancyId")]
        public IActionResult Get(int id)
        {
            return Ok(_vacanciesService.Get(id));
        }
        [HttpGet("nameVacancy/{name}", Name = "GetVacancyName")]
        public IActionResult Get(string name)
        {
            return Ok(_vacanciesService.Get(name));
        }
        [HttpPost("CreateVacancy")]
        public IActionResult Create(Vacancy vacancy)
        {
            _vacanciesService.Create(vacancy);
            return Ok();
        }
        [HttpPut("UpdateVacancy")]
        public IActionResult Update(Vacancy vacancy)
        {
            _vacanciesService.Edit(vacancy);
            return Ok();
        }
        [HttpDelete("DeleteVacancy")]
        public IActionResult Delete(int id)
        {
            _vacanciesService.Delete(id);
            return Ok();
        }
    }
}
