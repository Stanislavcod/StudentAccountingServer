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
            try
            {
                return Ok(_userService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("loginUser/{login}", Name = "GetUserLogin")]
        public IActionResult Get(string login)
        {
            try
            {
                return Ok(_userService.Get(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idUser/{id}", Name = "GetUserId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_userService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateUser")]
        public IActionResult Update(User user)
        {
            try
            {
                _userService.Edit(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletUser")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
