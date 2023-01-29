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
            try
            {
                return Ok(_trainingCoursesService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idTrainingCourses/{id}", Name = "GetTrainingCoursesId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_trainingCoursesService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameTrainingCourses/{name}", Name = "GetTrainingCoursesName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_trainingCoursesService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateTrainingCourses")]
        public IActionResult Create(TrainingCourses trainingCourses)
        {
            try
            {
                _trainingCoursesService.Create(trainingCourses);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateTrainingCourses")]
        public IActionResult Update(TrainingCourses trainingCourses)
        {
            try
            {
                _trainingCoursesService.Edit(trainingCourses);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTrainingCourses")]
        public IActionResult Delete(int id)
        {
            try
            {
                _trainingCoursesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
