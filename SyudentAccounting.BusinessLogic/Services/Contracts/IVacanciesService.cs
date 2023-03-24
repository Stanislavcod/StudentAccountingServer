
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IVacanciesService
    {
        void Create(Vacancy vacancy);
        IEnumerable<Vacancy> Get();
        Vacancy Get(string name);
        Vacancy Get(int id);
        IEnumerable<Vacancy> GetForStagesId(int stagesId);
        void Edit(Vacancy vacancy);
        void Delete(int id);
        IEnumerable<Vacancy> GetVacanciesPos(int participantsId);
        IEnumerable<Vacancy> GetFiltredVacancy(VacancyFilter filter);
    }
}
