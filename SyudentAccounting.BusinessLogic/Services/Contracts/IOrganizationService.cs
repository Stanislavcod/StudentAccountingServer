using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IOrganizationService
    {
        void Create(Organization organization);
        IEnumerable<Organization> Get();
        Organization Get(string name);
        Organization Get(int id);
        void Edit(Organization organization);
        void Delete(int id);
    }
}
