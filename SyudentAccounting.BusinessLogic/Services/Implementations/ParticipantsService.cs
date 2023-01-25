using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly ApplicationDatabaseContext _context;
        public ParticipantsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Participants newParticipant)
        {
            _context.Participants.Add(newParticipant);
            _context.SaveChanges();
        }
        public IEnumerable<Participants> Get()
        {
            return _context.Participants.Include(x => x.Individuals).Include(x => x.User).AsNoTracking().ToList();
        }
        public Participants Get(int id)
        {
            return _context.Participants.Include(x => x.Individuals).Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Participants newParticipants)
        {
            _context.Participants.Update(newParticipants);
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
