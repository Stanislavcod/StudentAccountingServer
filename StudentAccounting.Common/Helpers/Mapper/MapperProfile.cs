

using AutoMapper;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Common.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<EditPasswordUserDto, User>().ReverseMap();
        }
    }
}
