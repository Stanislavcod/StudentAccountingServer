using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model.DataBaseModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using StudentAccounting.Common.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using StudentAccounting.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace StudentAccounting.Controllers
{

    public class AccountController : Controller
    {
        readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpPost("Login")]
        //public IActionResult Login(LoginDTO model)
        //{
        //    try
        //    {
        //        User user = _userService.Get(model.Login, model.Password);
        //        if (user != null)
        //        {
        //            return Ok(_userService.Get(model.Login));
        //        }
        //        return BadRequest();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Ошибка");
        //    }
        //}

    }
}
