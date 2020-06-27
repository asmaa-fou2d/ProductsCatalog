
using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Business
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProductDto, Product>()
             .ReverseMap()
             .ForMember(p => p.CategoryName, opts => opts.MapFrom(src => src.Category.Name));

            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<WishListDto, WishList>()
            .ForMember(p => p.User, opts => opts.Ignore())
            .ForMember(p => p.Product, opts => opts.Ignore());

            CreateMap<WishList, WishListDto>()
             .ForMember(p => p.ProductName, opts => opts.MapFrom(src => src.Product.Name))
              .ForMember(p => p.ProductPrice, opts => opts.MapFrom(src => src.Product.Price))
              .ForMember(p => p.ProductPhoto, opts => opts.MapFrom(src => src.Product.Photo));
        }
    }
}
