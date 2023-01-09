
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IOrganizationService
    {
        void Create(Organization organization);
        IEnumerable<Organization> Get();
        Organization GetName(string name);
        void Edit(Organization organization);
        void Delete(Organization organization);
    }
}
