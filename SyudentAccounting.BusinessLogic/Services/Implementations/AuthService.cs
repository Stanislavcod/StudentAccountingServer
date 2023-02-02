

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.Helpers.Criptography;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDatabaseContext _context;
        private readonly ITokenService _tokenService;
        public AuthService(ApplicationDatabaseContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;   
        }
        private User AuthUser(LoginDTO loginDTO)
        {
            var user = _context.Users.SingleOrDefault(x => x.Login == loginDTO.Login);

            if (user == null) throw new Exception("Пользователь не найден.");

            if (PasswordHasher.VerifyPassordHash(user.PasswordSalt,user.PasswordHash,loginDTO.Password))
            {
                return user;
            }
            throw new Exception("Неверный пароль.");
        }
        public TokenDto Login(LoginDTO loginDTO)
        {
            var user = AuthUser(loginDTO);
            return _tokenService.GetToken(user);
        }
        public bool UserExists(string login)
        {
            return _context.Users.AsNoTracking().Any(x => x.Login == login.ToLower()) ? true : false;
        }
        public TokenDto Refresh(RefreshTokenDto refreshTokenDto)
        {
            return _tokenService.Refresh(refreshTokenDto);
        }
        public bool Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            PasswordHasher.CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _context.Users.Add(user);
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
