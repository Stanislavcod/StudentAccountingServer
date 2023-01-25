using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IIndividualsService
    {
        void Create(Individuals individualsDto);
        IEnumerable<Individuals> Get();
        Individuals Get(string name);
        Individuals Get(int id);
        void Edit(Individuals individualsDto);
        void Delete(int id);
    }
}
