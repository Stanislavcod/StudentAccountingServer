using Microsoft.Extensions.Logging;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.Constants;
using StudentAccounting.Common.Helpers.Criptography;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly ApplicationDatabaseContext _context;
        private readonly ITokenService _tokenService;
        private readonly UserService _userService;
        
        public AuthService(ApplicationDatabaseContext context, ITokenService tokenService, ILogger<AuthService> logger, 
            UserService userService)
        {
            _logger = logger;
            _userService = userService;
            _context = context;
            _tokenService = tokenService;
        }
        
        private User AuthUser(LoginDTO loginDTO)
        {
            var user = _userService.Get(loginDTO.Login);
            
            if (user == null)
            {
                _logger.LogInformation($"{DateTime.Now}: User with {loginDTO.Login} is not found.");

                return null;
            }
            
            if (PasswordHasher.VerifyPasswordHash(user.PasswordSalt, user.PasswordHash, loginDTO.Password))
            {
                return user;
            }

            return new User();
        }
        
        public TokenDto Login(LoginDTO loginDTO)
        {
            var user = AuthUser(loginDTO);
            
            _logger.LogInformation($"{DateTime.Now}: {loginDTO.Login} is login");
            
            return _tokenService.GetToken(user);
        }
        
        public bool UserExists(string login)
        {
            var user = _userService.Get(login.ToLower());

            if (user != null)
            {
                return true;
            }

            return false;
        }
        
        public TokenDto Refresh(RefreshTokenDto refreshTokenDto)
        {
            return _tokenService.Refresh(refreshTokenDto);
        }
        
        public bool Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Login = registerDto.Login,
                RoleId = registerDto.RoleId
            };
            
            PasswordHasher.CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            
            _logger.LogInformation($"{DateTime.Now}: Registration new {registerDto.Login}");
            
            _context.Users.Add(user);
            
            return _context.SaveChanges() > 0;
        }
        
        public bool RegisterAdmin()
        {
            if (!UserExists("admin"))
            {
                var admin = new User();
                
                PasswordHasher.CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
                
                admin.Login = "admin";
                admin.RoleId = _context.Roles.FirstOrDefault(x => x.Name == RoleType.Admin).Id;
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
