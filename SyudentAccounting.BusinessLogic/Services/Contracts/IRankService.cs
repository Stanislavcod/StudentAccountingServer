
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRankService
    {
        void Create(Rank Rank);
        IEnumerable<Rank> Get();
        Rank Get(string name);
        Rank Get(int id);
        void Edit(Rank Rank);
        void Delete(int id);
        IEnumerable<Rank> GetFiltredRanks(RankFilter filter);
    }
}
