
using AutoMapper;
using ProductsCatalog.Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Website
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProductDto, Website.Entities.Product>().ReverseMap();
        }
       
    }
}
