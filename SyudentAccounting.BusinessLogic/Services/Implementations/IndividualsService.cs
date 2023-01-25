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
            _context.Individuals.Add(newIndividuals);
            _context.SaveChanges();
        }
        public IEnumerable<Individuals> Get()
        {
            return _context.Individuals.AsNoTracking().ToList();
        }
        public Individuals Get(string name)
        {
            return _context.Individuals.AsNoTracking().FirstOrDefault(x => x.FIO == name);
        }
        public Individuals Get(int id)
        {
            return _context.Individuals.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Individuals newIndividuals)
        {
            _context.Individuals.Update(newIndividuals);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var individual = _context.Individuals.FirstOrDefault(x => x.Id == id);
            _context.Individuals.Remove(individual);
            _context.SaveChanges();
        }
    }
}
