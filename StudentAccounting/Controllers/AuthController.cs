using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpGet("RegisterAdmin")]
        public IActionResult RegisterAdmin()
        {
            var response = _authService.RegisterAdmin();
            
            return Ok(response);
        }
        
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDto)
        {
            var response = _authService.Login(loginDto);
            
            return Ok(response);
        }
        
        [Authorize(Roles = "Admin,DirectorOrganizational")]
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerModel)
        {
            if (_authService.UserExists(registerModel.Login))
            {
                return BadRequest("UserName Is Already Taken");
            }

            if (!_authService.Register(registerModel))
            {
                return BadRequest();
            }
            
            return Ok("user was registered");
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] RefreshTokenDto model)
        {
            var response = _authService.Refresh(model);
            
            return Ok(response);
        }
    }
}
