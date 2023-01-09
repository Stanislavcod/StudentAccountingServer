
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IPositionService
    {
        void Create(Position position);
        IEnumerable<Position> Get();
        Position GetName(string name);
        void Edit(Position position);
        void Delete(Position position);
    }
}
