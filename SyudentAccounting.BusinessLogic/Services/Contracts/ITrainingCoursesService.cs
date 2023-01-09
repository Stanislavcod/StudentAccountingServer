
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface ITrainingCoursesService
    {
        void Create(TrainingCourses trainingCourses);
        IEnumerable<TrainingCourses> Get();
        TrainingCourses GetName(string name);
        void Edit(TrainingCourses trainingCourses);
        void Delete(TrainingCourses trainingCourses);
    }
}
