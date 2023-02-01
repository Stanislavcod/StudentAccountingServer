﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                return Ok(_registrationForCoursesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
        [HttpPost("CreateRegistrationForCourses")]
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
        [HttpPut("UpdateRegistrationForCourses")]
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
        [HttpDelete("DeleteRegistrationForCourses")]
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
