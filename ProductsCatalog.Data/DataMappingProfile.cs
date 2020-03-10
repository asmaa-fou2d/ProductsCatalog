﻿
using AutoMapper;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Website.DTOs;

namespace ProductsCatalog.Website
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
        }
       
    }
}
