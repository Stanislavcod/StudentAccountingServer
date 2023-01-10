using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IParticipantsService
    {
        void Create(ParticipantsDto participantsDto);
        IEnumerable<ParticipantsDto> Get();
        ParticipantsDto Get(int id);
        void Edit(ParticipantsDto participantsDto);
        void Delete(int id);
    }
}
