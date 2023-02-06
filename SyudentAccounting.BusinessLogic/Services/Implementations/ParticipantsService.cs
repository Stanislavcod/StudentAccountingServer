using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using Org.BouncyCastle.Math.EC.Rfc7748;

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
            try
            {
                _context.Participants.Add(newParticipant);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Participants> Get()
        {
            try
            {
                return _context.Participants.Include(x => x.Individuals).Include(x => x.User).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Participants Get(int id)
        {
            try
            {
                return _context.Participants.Include(x => x.Individuals).Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Participants newParticipants)
        {
            try
            {
                _context.Participants.Update(newParticipants);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var participant = _context.Participants.FirstOrDefault(x => x.Id == id);
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Participants GetByUser(int userId)
        {
            try
            {
                return _context.Participants.Include(x => x.Individuals).Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.UserId == userId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
