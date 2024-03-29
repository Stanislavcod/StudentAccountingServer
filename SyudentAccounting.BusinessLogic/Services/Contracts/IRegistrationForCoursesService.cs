﻿using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRegistrationForCoursesService
    {
        void Create(RegistrationForCourses registrationForCourses);
        IEnumerable<RegistrationForCourses> Get();
        RegistrationForCourses Get(int id);
        void Edit(RegistrationForCourses registrationForCourses);
        void Delete(int id);
    }
}
