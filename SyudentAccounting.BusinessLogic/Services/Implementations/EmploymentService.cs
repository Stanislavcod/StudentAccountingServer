﻿using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class EmploymentService : IEmploymentService
    {
        private readonly ApplicationDatabaseContext _context;
        public EmploymentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Employment employment)
        {
            _context.Employments.Add(employment);
            _context.SaveChanges();
        }
        public IEnumerable<Employment> Get()
        {
            return _context.Employments.ToList();
        }
        public Employment Get(int id)
        {
            return _context.Employments.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Employment employment)
        {
            _context.Employments.Update(employment);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var employment = _context.Employments.FirstOrDefault(x => x.Id == id);
            _context.Employments.Remove(employment);
            _context.SaveChanges();
        }
    }
}