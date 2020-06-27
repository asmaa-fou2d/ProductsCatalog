
using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Website.ViewModels;

namespace ProductsCatalog.Website
{
    public class ViewMappingProfile : Profile
    {
        public ViewMappingProfile()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();

            CreateMap<LoginViewModel, User>();
            
            
        }
    }
}
