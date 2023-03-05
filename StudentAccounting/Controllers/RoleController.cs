using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        
        public RoleController(IRoleService service)
        {
            _roleService = service;
        }
        
        [HttpGet("GetRoles")]
        public ActionResult Get()
        {
            return Ok(_roleService.Get());
        }
    }
}
