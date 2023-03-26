using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;
        
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _departmentService = departmentService;
        }
        
        [Authorize]
        [HttpGet("GetDepartment")]
        public ActionResult<IEnumerable<Department>> Get()
        {
            try
            {
                return Ok(_departmentService.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize]
        [HttpGet("idDepartment/{id}", Name = "GetDepartmentId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_departmentService.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetDepartmentByParticipantsCount")]
        public IActionResult GetParticipantsCount(int id)
        {
            try
            {
                return Ok(_departmentService.GetDepartmentByParticipantsCount(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("nameDepartment/{name}", Name = "GetDepartmentName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_departmentService.Get(name));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateDepartment")]
        public IActionResult Create(Department department)
        {
            try
            {
                _departmentService.Create(department);
                
                _logger.LogInformation($"{DateTime.Now}: Create new department");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin,Director,DirectorOrganizational")]
        [HttpPut("UpdateDepartment")]
        public IActionResult Update(Department department)
        {
            try
            {
                _departmentService.Edit(department);
                
                _logger.LogInformation($"{DateTime.Now}: Edit department with {department.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete(int id)
        {
            try
            {
                _departmentService.Delete(id);
                
                _logger.LogInformation($"{DateTime.Now}: Delete department with {id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetFiltredDepartment")]
        public IActionResult GetFiltredDepartment(DepartmentFilter filter)
        {
            try
            {
                _departmentService.GetFiltredDepartment(filter);

                _logger.LogInformation($"{DateTime.Now}: Get departmentFiltered");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return BadRequest(ex.Message);
            }
        }
    }
}
