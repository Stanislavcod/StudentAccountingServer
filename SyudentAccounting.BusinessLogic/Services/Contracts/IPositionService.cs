using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IPositionService
    {
        void Create(Position position);
        IEnumerable<Position> Get();
        Position Get(string name);
        Position Get(int id);
        IEnumerable<Position> GetForDepartmentId(int departmentId);
        void Edit(Position position);
        void Delete(int id);
        IEnumerable<Position> GetFiltredPosition(PositionFilter filter);
    }
}
