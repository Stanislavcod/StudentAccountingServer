using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService service;
        public RoleController(IRoleService service)
        {
            this.service = service;
        }
        [HttpGet("GetRoles")]
        public ActionResult Get()
        {
            return Ok(service.Get());
        }
    }
}
