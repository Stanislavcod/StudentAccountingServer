using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDatabaseContext _context;
        public UserService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        public IEnumerable<User> Get()
        {
            return _context.Users.AsNoTracking().ToList();
        }
        public User Get(string name)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Login == name);
        }
        public User Get(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(User newUser)
        {
            _context.Users.Update(newUser);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
