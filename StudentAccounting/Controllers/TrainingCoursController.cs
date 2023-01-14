using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class TrainingCoursController : Controller
    {
        private readonly ITrainingCoursesService _trainingCoursesService;
        public TrainingCoursController(ITrainingCoursesService trainingCoursesService)
        {
            _trainingCoursesService = trainingCoursesService;
        }
        [HttpGet("GetTrainingCourses")]
        public ActionResult<IEnumerable<TrainingCourses>> Get()
        {
            return Ok(_trainingCoursesService.Get());
        }
        [HttpGet("idTrainingCourses/{id}", Name = "GetTrainingCoursesId")]
        public IActionResult Get(int id)
        {
            return Ok(_trainingCoursesService.Get(id));
        }
        [HttpGet("nameTrainingCourses/{name}", Name = "GetTrainingCoursesName")]
        public IActionResult Get(string name)
        {
            return Ok(_trainingCoursesService.Get(name));
        }
        [HttpPost("CreateTrainingCourses")]
        public IActionResult Create(TrainingCourses trainingCourses)
        {
            _trainingCoursesService.Create(trainingCourses);
            return Ok();
        }
        [HttpPut("UpdateTrainingCourses")]
        public IActionResult Update(TrainingCourses trainingCourses)
        {
            _trainingCoursesService.Edit(trainingCourses);
            return Ok();
        }
        [HttpDelete("DeleteTrainingCourses")]
        public IActionResult Delete(int id)
        {
            _trainingCoursesService.Delete(id);
            return Ok();
        }
    }
}
