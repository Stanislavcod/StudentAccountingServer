using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class RoleService: IRoleService
    {
        private readonly ApplicationDatabaseContext _context;
        public RoleService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<RoleDto> Get()
        {
            var roleDtos = _context.Roles.AsNoTracking().Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name.ToString(),
            }).ToList();
            if (roleDtos == null) throw new Exception();
            return roleDtos;
        }
    }
}
