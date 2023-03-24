using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDatabaseContext _context;
        private readonly SymmetricSecurityKey _key;
        
        public TokenService(IConfiguration config, ApplicationDatabaseContext context)
        {
            _config = config;
            _context = context;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JWT:TokenKey"]));
        }
        
        private JwtSecurityToken CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name.ToString())
            };
            
            var signIn = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);
            
            var jwt = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn,
                notBefore: DateTime.UtcNow
                );
            
            return jwt;
        }
        
        private RefreshToken AddRefreshToken(User user)
        {
            var token = new RefreshToken
            {
                Id = new JwtSecurityTokenHandler().WriteToken(CreateToken(user)),
                UserId = user.Id,
                ValidTo = DateTime.UtcNow.AddDays(2),
                ValidFrom = DateTime.UtcNow
            };
            
            _context.RefreshToken.Add(token);
            _context.SaveChanges();
            
            return token;
        }
        
        public TokenDto GetToken(User user)
        {
            var token = CreateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedJwt = tokenHandler.WriteToken(token);
            var refreshToken = AddRefreshToken(user);
            
            var userDto = new UserDto()
            {
                Id = user.Id,
                Login = user.Login,
                RoleId = user.RoleId,
                Role = new RoleDto { Name = user.Role.Name.ToString() }
            };
            
            return new TokenDto
            {
                UserId = user.Id,
                Token = encodedJwt,
                RefreshToken = refreshToken.Id,
                User = userDto,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo
            };
        }
        
        public TokenDto Refresh(RefreshTokenDto refreshTokenDto)
        {
            var refreshToken = _context.RefreshToken.FirstOrDefault(x => x.Id == refreshTokenDto.RefreshToken);

            if (refreshToken == null)
            {
                return new TokenDto();
            }

            if (refreshToken.ValidTo < DateTime.UtcNow)
            {
                return new TokenDto();
            }

            var user = _context.Users.FirstOrDefault(x => x.Login == refreshTokenDto.Login);
            
            if (user == null)
            {
                return new TokenDto();
            }

            _context.RefreshToken.Remove(refreshToken);
            _context.SaveChanges();
            
            return GetToken(user);
        }
    }
}
