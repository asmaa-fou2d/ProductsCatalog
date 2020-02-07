using AutoMapper;
using ProductsCatalog.Business;
using ProductsCatalog.Website;

namespace ProductsCatalog.Website.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DataMappingProfile());
                cfg.AddProfile(new ViewMappingProfile());
            });
        }
    }
}