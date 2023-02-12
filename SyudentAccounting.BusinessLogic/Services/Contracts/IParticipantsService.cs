using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IParticipantsService
    {
        void Create(Participants participantsDto);
        IEnumerable<Participants> Get();
        Participants Get(int id);
        void Edit(Participants participantsDto);
        void Delete(int id);
        Participants GetByUser(int userId);
        Participants GetByIndividualName(string individualName);
    }
}
