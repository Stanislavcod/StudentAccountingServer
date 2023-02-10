using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Controllers
{
    public class ScheduleOfClassesController : Controller
    {
        private readonly IScheduleOfСlassesService _scheduleOfСlassesService;
        public ScheduleOfClassesController(IScheduleOfСlassesService scheduleOfСlassesService)
        {
            _scheduleOfСlassesService = scheduleOfСlassesService;
        }
        [Authorize]
        [HttpGet("GetScheduleOfСlasses")]
        public ActionResult<IEnumerable<ScheduleOfСlasses>> Get()
        {
            try
            {
                return Ok(_scheduleOfСlassesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("ScheduleOfClassesForCoursesId")]
        public ActionResult<IEnumerable<ScheduleOfСlasses>> GetForCoursesId(int coursesId)
        {
            try
            {
                return Ok(_scheduleOfСlassesService.GetForCoursesId(coursesId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idScheduleOfСlasses/{id}", Name = "GetScheduleOfСlassesId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_scheduleOfСlassesService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateScheduleOfСlasses")]
        public IActionResult Create(ScheduleOfСlasses schedule)
        {
            try
            {
                _scheduleOfСlassesService.Create(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateScheduleOfСlasses")]
        public IActionResult Update(ScheduleOfСlasses schedule)
        {
            try
            {
                _scheduleOfСlassesService.Edit(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteScheduleOfСlasses")]
        public IActionResult Delete(int id)
        {
            try
            {
                _scheduleOfСlassesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
