using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class IndividualsService : IIndividualsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;
        public IndividualsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(IndividualsDto newIndividuals)
        {
            var individuals = _mapper.Map<Individuals>(newIndividuals);
            _context.Individuals.Add(individuals);
            _context.SaveChanges();
        }
        public IEnumerable<IndividualsDto> Get()
        {
            var individuals = _context.Individuals.AsNoTracking().ToList();
            var individualsDto = _mapper.Map<List<IndividualsDto>>(individuals);
            return individualsDto;
        }
        public IndividualsDto Get(string name)
        {
            var individuals = _context.Individuals.FirstOrDefault(x => x.FIO == name);
            var individualsDto = _mapper.Map<IndividualsDto>(individuals);
            return individualsDto;
        }
        public IndividualsDto Get(int id)
        {
            var individuals = _context.Individuals.FirstOrDefault(x => x.Id == id);
            var individualsDto = _mapper.Map<IndividualsDto>(individuals);
            return individualsDto;
        }
        public void Edit(IndividualsDto newIndividuals)
        {
            var individuals = _mapper.Map<Individuals>(newIndividuals);
            _context.Individuals.Update(individuals);
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
