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
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Произошла ошибка при создании нового пользователя", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка", ex);
            }
        }
        public IEnumerable<User> Get()
        {
            try
            {
                return _context.Users.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла ошибка при получении всех пользователей", ex);
            }
        }
        public User Get(string name)
        {
            try
            {
                return _context.Users.AsNoTracking().FirstOrDefault(x => x.Login == name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Произошла ошибка при получении пользователя по имени {name}", ex);
            }
        }
        public User Get(int id)
        {
            try
            {
                return _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Произошла ошибка при получении пользователя по идентификатору {id}", ex);
            }
        }
        public User Get(string login, string password)
        {
            try
            {
                return _context.Users.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла ошибка при получении пользователя по логину и паролю", ex);
            }
        }
        public void Edit(User newUser)
        {
            try
            {
                _context.Users.Update(newUser);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Произошла ошибка при обновлении пользователя", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Произошла ошибка при удалении пользователя", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка", ex);
            }
        }
    }
}
