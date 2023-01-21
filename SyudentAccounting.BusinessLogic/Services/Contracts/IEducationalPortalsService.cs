
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEducationalPortalsService
    {
        void Create(EducationalPortals educationalPortals);
        IEnumerable<EducationalPortals> Get();
        Vacancy Get(string name);
        Vacancy Get(int id);
        void Edit(EducationalPortals educationalPortals);
        void Delete(int id);
    }
}
