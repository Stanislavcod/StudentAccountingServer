using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class IndividualsService : IIndividualsService
    {
        private readonly ApplicationDatabaseContext _context;
        public IndividualsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Individuals newIndividuals)
        {
            try
            {
                _context.Individuals.Add(newIndividuals);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Individuals> Get()
        {
            try
            {
                return _context.Individuals.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Individuals Get(string name)
        {
            try
            {
                return _context.Individuals.AsNoTracking().FirstOrDefault(x => x.FIO == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Individuals Get(int id)
        {
            try
            {
                return _context.Individuals.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Individuals newIndividuals)
        {
            try
            {
                _context.Individuals.Update(newIndividuals);
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
                var individual = _context.Individuals.FirstOrDefault(x => x.Id == id);
                _context.Individuals.Remove(individual);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
