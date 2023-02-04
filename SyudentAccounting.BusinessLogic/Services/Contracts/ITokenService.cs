using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface ITokenService
    {
        TokenDto GetToken(User user);
        TokenDto Refresh(RefreshTokenDto refreshToken);
    }
}
