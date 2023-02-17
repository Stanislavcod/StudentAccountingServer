using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpGet("GetUsers")]
        public ActionResult Get()
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPut("loginUser/{login}", Name = "GetUserLogin")]
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPut("idUser/{id}", Name = "GetUserId")]
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
        [HttpPut("ForgotPassword")]
        public IActionResult ForgotPassword(string login)
        {
            try
            {
                _userService.ForgotPassword(login);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,DirectorOrganizational")]
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
        [Authorize(Roles = "Admin,DirectorOrganizational")]
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
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePasswordUser,DirectorOrganizational")]
        public IActionResult UpdatePassword(EditPasswordUserDto editPasswordUserDto)
        {
            try
            {
                _userService.EditPassword(editPasswordUserDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
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
