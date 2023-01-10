using AutoMapper;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Individuals, IndividualsDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Participants, ParticipantsDto>().ReverseMap();
            CreateMap<Student,StudentDto>().ReverseMap();
        }
    }
}
