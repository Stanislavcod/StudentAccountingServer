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
        private readonly ApplicationDatabaseContext _context;
        private readonly ITokenService _tokenService;
        public AuthService(ApplicationDatabaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        private User AuthUser(LoginDTO loginDTO)
        {
            var user = _context.Users.Include(x=> x.Role).SingleOrDefault(x => x.Login == loginDTO.Login);

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
 
            User user = new User()
            {
                Login = registerDto.Login,
                RoleId = registerDto.RoleId
            };
            PasswordHasher.CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _context.Users.Add(user);
            return _context.SaveChanges() > 0 ? true : false;
        }
        public bool RegisterAdmin()
        {
           
            if (!UserExists("admin"))
            {
                User admin = new User();
                PasswordHasher.CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
                admin.Login = "admin";
                admin.RoleId = 2;
                admin.PasswordSalt = passwordSalt;
                admin.PasswordHash = passwordHash;
                _context.Users.Add(admin);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
