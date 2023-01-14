
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface ITrainingCoursesService
    {
        void Create(TrainingCourses trainingCourses);
        IEnumerable<TrainingCourses> Get();
        TrainingCourses Get(string name);
        TrainingCourses Get(int id);
        void Edit(TrainingCourses trainingCourses);
        void Delete(int id);
    }
}
