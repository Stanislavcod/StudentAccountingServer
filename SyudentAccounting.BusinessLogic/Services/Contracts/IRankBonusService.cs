using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRankBonusService
    {
        void Create(RankBonus rankBonus);
        IEnumerable<RankBonus> Get();
        RankBonus Get(int id);
        void Edit(RankBonus rankBonus);
        void Delete(int rankId, int bonusId);
    }
}
