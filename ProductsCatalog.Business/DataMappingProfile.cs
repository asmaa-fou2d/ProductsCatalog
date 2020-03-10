
using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Data.Entities;

namespace ProductsCatalog.Business
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
        }
       
    }
}
