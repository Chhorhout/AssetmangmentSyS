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
            CreateMap<AssetUpdateDto, Asset>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<UserCreateDto, User>();
            CreateMap<MaintainerCreateDto, Maintainer>();
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<SupplierCreateDto, SupplierResponseDto>();
            CreateMap<Asset, AssetResponseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Supplier.Id));
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<Supplier, SupplierResponseDto>();
            CreateMap<Supplier, SupplierCreateDto>();
        
        }
    }
} 