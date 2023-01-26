using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class ScheduleOfClassesController : Controller
    {
        private readonly IScheduleOfСlassesService _scheduleOfСlassesService;
        public ScheduleOfClassesController(IScheduleOfСlassesService scheduleOfСlassesService)
        {
            _scheduleOfСlassesService = scheduleOfСlassesService;
        }
        [HttpGet("GetBScheduleOfСlasses")]
        public ActionResult<IEnumerable<ScheduleOfСlasses>> Get()
        {
            return Ok(_scheduleOfСlassesService.Get());
        }
        [HttpGet("idScheduleOfСlasses/{id}", Name = "GetScheduleOfСlassesId")]
        public IActionResult Get(int id)
        {
            return Ok(_scheduleOfСlassesService.Get(id));
        }
        [HttpPost("CreateScheduleOfСlasses")]
        public IActionResult Create(ScheduleOfСlasses schedule)
        {
            _scheduleOfСlassesService.Create(schedule);
            return Ok();
        }
        [HttpPut("UpdateScheduleOfСlasses")]
        public IActionResult Update(ScheduleOfСlasses schedule)
        {
            _scheduleOfСlassesService.Edit(schedule);
            return Ok();
        }
        [HttpDelete("DeleteScheduleOfСlasses")]
        public IActionResult Delete(int id)
        {
            _scheduleOfСlassesService.Delete(id);
            return Ok();
        }
    }
}
