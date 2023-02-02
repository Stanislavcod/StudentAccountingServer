

using AutoMapper;
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
        private readonly IMapper _mapper;
        public TokenService(IConfiguration config, ApplicationDatabaseContext context, IMapper mapper)
        {
            _config = config;
            _context = context;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JWT:TokenKey"]));
            _mapper = mapper;
        }
        public JwtSecurityToken CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Login)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);
            var Jwt = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds,
                notBefore: DateTime.UtcNow
                );
            return Jwt;
        }
        private RefreshToken AddRefreshToken(User user)
        {
            var now = DateTime.UtcNow;
            var token = new RefreshToken
            {
                Id = new JwtSecurityTokenHandler().WriteToken(CreateToken(user)),
                UserId = user.Id,
                ValidTo = now.AddDays(2),
                ValidFrom = now
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
            var mappedUser = _mapper.Map<User, UserDto>(user);
            return new TokenDto
            {
                UserId = user.Id,
                Token = encodedJwt,
                RefreshToken = refreshToken.Id,
                User = mappedUser,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo
            };
        }
        public TokenDto Refresh(RefreshTokenDto refreshTokenDto)
        {
            var refreshToken = _context.RefreshToken.FirstOrDefault(x => x.Id == refreshTokenDto.RefreshToken);

            if (refreshToken == null) throw new Exception("refreshIsExpired");
            if (refreshToken.ValidTo < DateTime.UtcNow) throw new Exception("refreshIsExpired");

            var user = _context.Users.FirstOrDefault(x => x.Login == refreshTokenDto.Login);
            if (user == null) throw new Exception("Пользователь не найден");

            _context.RefreshToken.Remove(refreshToken);
            _context.SaveChanges();
            return GetToken(user);
        }
    }
}
