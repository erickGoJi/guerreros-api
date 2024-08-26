using AutoMapper;
using api.guerreros.Models;
using biz.guerreros.Entities;
using biz.guerreros.Models;

namespace api.guerreros.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Users, UserCreateDto>().ReverseMap();
            CreateMap<Users, UserUpdateDto>().ReverseMap(); 
            #endregion

            #region Catalogues

            CreateMap<CatAgeRange, CatAgeRangeDto>().ReverseMap();
            CreateMap<CatDiseases, CatDiseasesDto>().ReverseMap();

            #endregion

        }
    }
}
