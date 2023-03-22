﻿using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class RankService : IRankService
    {
        private readonly ApplicationDatabaseContext _context;
        public RankService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Rank Rank)
        {
            try
            {
                _context.Ranks.Add(Rank);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Rank> Get()
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).Include(x=> x.RankBonus).ThenInclude(x=> x.Bonus).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Rank Get(int id)
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).Include(x => x.RankBonus).ThenInclude(x => x.Bonus).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Rank Get(string name)
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).Include(x => x.RankBonus).ThenInclude(x => x.Bonus).AsNoTracking().FirstOrDefault(x => x.RankName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Rank Rank)
        {
            try
            {
                _context.Ranks.Update(Rank);
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
                var Rank = _context.Ranks.FirstOrDefault(x => x.Id == id);
                _context.Ranks.Remove(Rank);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Rank> GetFiltredApplicationInTheProject(RankFilter filter)
        {
            var quary = _context.Ranks.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                quary = quary.Where(rank => rank.RankName.ToLower().Contains(filter.Name));
            }
            //фильтр по рейтингу не работает
            //if (filter.MmrFrom is not 0)
            //{
            //    quary = quary.Where(rank => rank..DateEntry.Year == filter.DateYear);
            //}


            var applicationInTheProject = quary.ToList();

            return applicationInTheProject;
        }
    }
}
