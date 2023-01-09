using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly ApplicationDatabaseContext _context;
        public ParticipantsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Participants participants)
        {
            _context.Participants.Add(participants);
            _context.SaveChanges();
        }
        public IEnumerable<Participants> Get()
        {
            return _context.Participants.ToList();
        }
        public Participants GetId(int id)
        {
            return _context.Participants.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Participants participants)
        {
            _context.Participants.Update(participants);
            _context.SaveChanges();
        }
        public void Delete(Participants participants)
        {
            _context.Participants.Remove(participants);
            _context.SaveChanges();
        }
    }
}
