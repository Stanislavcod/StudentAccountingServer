using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IAuthService
    {
        TokenDto Login(LoginDTO loginDTO);
        TokenDto Refresh(RefreshTokenDto refreshTokenDto);
        bool Register(RegisterDto registerDto);
        public bool RegisterAdmin();
        bool UserExists(string login);
    }
}
