using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

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
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            return Ok(_userService.Get());
        }
        [HttpGet("loginUser/{login}", Name = "GetUserLogin")]
        public IActionResult Get(string login)
        {
            return Ok(_userService.Get(login));
        }
        [HttpGet("idUser/{id}", Name ="GetUserId")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }
        [HttpPost("CreateUser")]
        public IActionResult Create(UserDto userDto)
        {
            _userService.Create(userDto);
            return Ok();
        }
        [HttpPut("UpdateUser")]
        public IActionResult Update(UserDto userDto)
        {
            _userService.Edit(userDto);
            return Ok();
        }
        [HttpDelete("DeletUser")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
