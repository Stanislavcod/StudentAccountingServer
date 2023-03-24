using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDatabaseContext _context;
        public PositionService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Position position)
        {
            try
            {
                _context.Positions.Add(position);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Position> Get()
        {
            try
            {
                return _context.Positions.Include(x => x.Department).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Position Get(string name)
        {
            try
            {
                return _context.Positions.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.FullName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Position Get(int id)
        {
            try
            {
                return _context.Positions.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Position> GetForDepartmentId(int departmentId)
        {
            try
            {
                return _context.Positions.Include(x => x.Department).Where(x=> x.DepartmentId == departmentId).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Position position)
        {
            try
            {
                _context.Positions.Update(position);
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
                var position = _context.Positions.FirstOrDefault(x => x.Id == id);
                _context.Positions.Remove(position);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Position> GetFiltredPosition(PositionFilter filter)
        {
            var quary = _context.Positions.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                quary = quary.Where(position => position.FullName.ToLower().Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Department))
            {
                quary = quary.Where(position => position.Department.FullName.ToLower().Contains(filter.Department));
            }

            var positions = quary.ToList();

            return positions;
        }
    }
}
