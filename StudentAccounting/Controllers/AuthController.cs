using Microsoft.AspNetCore.Mvc;
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Common.ModelsDto;
using System.Security.Cryptography;
using StudentAccounting.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace StudentAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        public static User user = new User();
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordhash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Login = request.Login;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if(user.Login != request.Login)
            {
                return BadRequest("Пользователь не найден");
            }
            if(!VerifyPassordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Неверный пароль!");
            }
            string token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private bool VerifyPassordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
