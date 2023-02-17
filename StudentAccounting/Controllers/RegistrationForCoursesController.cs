using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Controllers
{
    public class RegistrationForCoursesController : Controller
    {
        private readonly IRegistrationForCoursesService _registrationForCoursesService;
        public RegistrationForCoursesController(IRegistrationForCoursesService registrationForCoursesService)
        {
            _registrationForCoursesService = registrationForCoursesService;
        }
        [Authorize]
        [HttpGet("GetRegistrationForCourses")]
        public ActionResult<IEnumerable<RegistrationForCourses>> Get()
        {
            try
            {
                return Ok(_registrationForCoursesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idRegistrationForCourses/{id}", Name = "GetRegistrationForCoursesId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_registrationForCoursesService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRegistrationForCourses,DirectorOrganizational")]
        public IActionResult Create(RegistrationForCourses registrationForCourses)
        {
            try
            {
                _registrationForCoursesService.Create(registrationForCourses);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRegistrationForCourses,DirectorOrganizational")]
        public IActionResult Update(RegistrationForCourses registrationForCourses)
        {
            try
            {
                _registrationForCoursesService.Edit(registrationForCourses);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteRegistrationForCourses,DirectorOrganizational")]
        public IActionResult Delete(int id)
        {
            try
            {
                _registrationForCoursesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
