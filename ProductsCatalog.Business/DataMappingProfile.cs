
using AutoMapper;
using ProductsCatalog.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProductDto, Data.Entities.Product>().ReverseMap();
        }
       
    }
}
