using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.Get());
        }
        [HttpGet("GetUser")]
        public IActionResult Get(string login)
        {
            return Ok(_userService.GetName(login));
        }
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            _userService.Create(user);
            return Ok();
        }
        [HttpPut("UpdateUser")]
        public IActionResult Update(User user)
        {
            _userService.Edit(user);
            return Ok();
        }
        [HttpDelete("DeletUser")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }
    }
}
