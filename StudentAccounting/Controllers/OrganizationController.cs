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
            return Ok(_organizationService.Get());
        }
        [HttpGet("idOrganization/{id}", Name = "GetOrganizationId")]
        public IActionResult Get(int id)
        {
            return Ok(_organizationService.Get(id));
        }
        [HttpGet("nameOrganization/{name}", Name = "GetOrganizationName")]
        public IActionResult Get(string name)
        {
            return Ok(_organizationService.Get(name));
        }
        [HttpPost("CreateOrganization")]
        public IActionResult Create(Organization organization)
        {
            _organizationService.Create(organization);
            return Ok();
        }
        [HttpPut("UpdateOrganization")]
        public IActionResult Update(Organization organization)
        {
            _organizationService.Edit(organization);
            return Ok();
        }
        [HttpDelete("DeleteOrganization")]
        public IActionResult Delete(int id)
        {
            _organizationService.Delete(id);
            return Ok();
        }
    }
}
