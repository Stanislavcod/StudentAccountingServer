
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IParticipantsService
    {
        void Create(Participants participants);
        IEnumerable<Participants> Get();
        Participants GetId(int id);
        void Edit(Participants participants);
        void Delete(Participants participants);
    }
}
