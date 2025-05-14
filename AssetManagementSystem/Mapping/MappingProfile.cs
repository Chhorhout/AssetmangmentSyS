using AutoMapper;
using AssetManagementSystem.Models;
using AssetManagementSystem.Dtos;


namespace AssetManagementSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<UserCreateDto, User>();
            CreateMap<MaintainerCreateDto, Maintainer>();
            // Add more mappings as needed]
        }
    }
} 