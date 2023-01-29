using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class OrganizationController : Controller
    {
       private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [HttpGet("GetOrganization")]
        public ActionResult<IEnumerable<Organization>> Get()
        {
            try
            {
                return Ok(_organizationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idOrganization/{id}", Name = "GetOrganizationId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_organizationService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nameOrganization/{name}", Name = "GetOrganizationName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_organizationService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateOrganization")]
        public IActionResult Create(Organization organization)
        {
            try
            {
                _organizationService.Create(organization);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateOrganization")]
        public IActionResult Update(Organization organization)
        {
            try
            {
                _organizationService.Edit(organization);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteOrganization")]
        public IActionResult Delete(int id)
        {
            try
            {
                _organizationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
