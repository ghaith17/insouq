using AutoMapper;
using insouq.Models;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CategoryDTOS;
using insouq.Shared.DTOS.TypeDTOS;
using insouq.Shared.DTOS.UserDTOS;

namespace insouq.Services.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Type, TypeDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<SubType, SubTypeDTO>().ReverseMap();
            CreateMap<CompanyProfile, CompanyProfileDTO>().ReverseMap();
            CreateMap<Ad, MotorsAdDTO>().ReverseMap();
        }
    }
}