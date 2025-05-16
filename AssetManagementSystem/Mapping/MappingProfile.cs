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
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<Asset, AssetResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
            
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<Supplier, SupplierResponseDto>();
        
        }
    }
} 