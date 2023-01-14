﻿using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IIndividualsService
    {
        void Create(IndividualsDto individualsDto);
        IEnumerable<IndividualsDto> Get();
        IndividualsDto Get(string name);
        IndividualsDto Get(int id);
        void Edit(IndividualsDto individualsDto);
        void Delete(int id);
    }
}