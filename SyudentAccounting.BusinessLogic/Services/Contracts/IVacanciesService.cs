
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IVacanciesService
    {
        void Create(Vacancy vacancy);
        IEnumerable<Vacancy> Get();
        Vacancy GetName(string name);
        void Edit(Vacancy vacancy);
        void Delete(Vacancy vacancy);
    }
}
