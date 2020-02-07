
using AutoMapper;
using ProductsCatalog.Website.DTOs;
using ProductsCatalog.Website.ViewModels;

namespace ProductsCatalog.Website
{
    public class ViewMappingProfile : Profile
    {
        public ViewMappingProfile()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
        }
    }
}
