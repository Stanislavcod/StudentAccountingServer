using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEducationalPortalsService
    {
        void Create(EducationalPortals educationalPortals);
        IEnumerable<EducationalPortals> Get();
        EducationalPortals Get(string name);
        EducationalPortals Get(int id);
        void Edit(EducationalPortals educationalPortals);
        void Delete(int id);
    }
}
