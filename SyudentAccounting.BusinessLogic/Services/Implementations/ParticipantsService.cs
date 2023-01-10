using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using StudentAccounting.Common.ModelsDto;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;
        public ParticipantsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(ParticipantsDto newParticipant)
        {
            var participant = _mapper.Map<Participants>(newParticipant);
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }
        public IEnumerable<ParticipantsDto> Get()
        {
            var participants = _context.Participants.AsNoTracking().ToList();
            var participantsDto = _mapper.Map<List<ParticipantsDto>>(participants);
            return participantsDto;
        }
        public ParticipantsDto Get(int id)
        {
            var participant = _context.Participants.FirstOrDefault(x => x.Id == id);
            var participantDto = _mapper.Map<ParticipantsDto>(participant);
            return participantDto;
        }
        public void Edit(ParticipantsDto newParticipants)
        {
            var participant = _mapper.Map<Participants>(newParticipants);
            _context.Participants.Update(participant);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var participant = _context.Participants.FirstOrDefault(x => x.Id == id);
            _context.Participants.Remove(participant);
            _context.SaveChanges();
        }
    }
}
