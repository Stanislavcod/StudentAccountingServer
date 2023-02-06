using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.Common.Helpers.Criptography;
using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IEmailService _emailService;
        public UserService(ApplicationDatabaseContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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
        public IEnumerable<UserDto> Get()
        {
            try
            {
                var userDtos = _context.Users.Include(x => x.Role).AsNoTracking().Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    RoleId = u.RoleId,
                    Role = u.Role != null ? new RoleDto { Id = u.Role.Id, Name = u.Role.Name.ToString() } : null
                }).ToList();
                return userDtos;
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
        public void Edit(User model)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(x => x.Id == model.Id);
                user.Login=model.Login;
                user.RoleId = model.RoleId;
                _context.Users.Update(user);
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
        public void EditPassword(EditPasswordUserDto editPasswordUserDto)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(x=>x.Id==editPasswordUserDto.Id);
                PasswordHasher.CreatePasswordHash(editPasswordUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                _context.Users.Update(user);
                _context.SaveChanges();
                string email = _context.Participants.Include(x => x.Individuals).FirstOrDefault(x => x.UserId == user.Id).Individuals.Mail;
                string subject = "New password PolessUp";
                string message = $"Здравствуйте! Ваш новый пароль {editPasswordUserDto.Password}";
                _emailService.SendEmailMessage(email,subject, message);
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
        public void ForgotPassword(string login)
        {
            try
            {
                string email = _context.Participants.Include(x => x.Individuals).Include(x => x.User).FirstOrDefault(x => x.User.Login == login).Individuals.Mail;
                string subject = "New password PolessUp";
                string password = RandomPassword.RandomUserPassword();
                string message = $"Здравствуйте! Ваш новый пароль {password}";
                _emailService.SendEmailMessage(email, subject, message);
                User user = _context.Users.FirstOrDefault(x => x.Login == login);
                PasswordHasher.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                _context.Users.Update(user);
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
