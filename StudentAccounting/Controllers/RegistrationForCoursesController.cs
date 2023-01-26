using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class RegistrationForCoursesController : Controller
    {
        private readonly IRegistrationForCoursesService _registrationForCoursesService;
        public RegistrationForCoursesController(IRegistrationForCoursesService registrationForCoursesService)
        {
            _registrationForCoursesService = registrationForCoursesService;
        }
        [HttpGet("GetRegistrationForCourses")]
        public ActionResult<IEnumerable<RegistrationForCourses>> Get()
        {
            return Ok(_registrationForCoursesService.Get());
        }
        [HttpGet("idRegistrationForCourses/{id}", Name = "GetRegistrationForCoursesId")]
        public IActionResult Get(int id)
        {
            return Ok(_registrationForCoursesService.Get(id));
        }
        [HttpPost("CreateRegistrationForCourses")]
        public IActionResult Create(RegistrationForCourses registrationForCourses)
        {
            _registrationForCoursesService.Create(registrationForCourses);
            return Ok();
        }
        [HttpPut("UpdateRegistrationForCourses")]
        public IActionResult Update(RegistrationForCourses registrationForCourses)
        {
            _registrationForCoursesService.Edit(registrationForCourses);
            return Ok();
        }
        [HttpDelete("DeleteRegistrationForCourses")]
        public IActionResult Delete(int id)
        {
            _registrationForCoursesService.Delete(id);
            return Ok();
        }
    }
}
