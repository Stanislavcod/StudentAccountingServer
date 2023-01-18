
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IVacanciesService
    {
        void Create(Vacancy vacancy);
        IEnumerable<Vacancy> Get();
        Vacancy Get(string name);
        Vacancy Get(int id);
        void Edit(Vacancy vacancy);
        void Delete(int id);
        IEnumerable<Vacancy> Get(Participants participants);
    }
}
