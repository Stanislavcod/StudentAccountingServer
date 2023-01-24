using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using StudentAccounting.Common.ModelsDto;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(UserDto newUser)
        {
            var userDto = _mapper.Map<User>(newUser);
            _context.Users.Add(userDto);
            _context.SaveChanges();
        }
        public IEnumerable<UserDto> Get()
        {
            var users = _context.Users.AsNoTracking().ToList();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        public UserDto Get(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == name);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public UserDto Get(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public void Edit(UserDto newUser)
        {
            var user = _mapper.Map<User>(newUser);
            _context.Users.Update(user);
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
