using System;
using AutoMapper;
using Catalog.Application.Queries.AdditionalServiceQueries;
using Catalog.Application.Queries.AppSettingQueries;
using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Queries.CategoryQueries;
using Catalog.Application.Queries.CollectionGroupQueries;
using Catalog.Application.Queries.CollectionQueries;
using Catalog.Application.Queries.LocationQueries;
using Catalog.Application.Queries.MealQueries;
using Catalog.Application.Queries.ProductQueries;
using Catalog.Application.Queries.SellerQueries;

namespace Catalog.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AdditionalServiceMappingConfiguration.Configure(cfg);
            AppSettingMappingConfiguration.Configure(cfg);
            BrandMappingConfiguration.Configure(cfg);
            CategoryMappingConfiguration.Configure(cfg);
            CollectionGroupMappingConfiguration.Configure(cfg);
            CollectionMappingConfiguration.Configure(cfg);
            LocationMappingConfiguration.Configure(cfg);
            ProductMappingConfiguration.Configure(cfg);
            SellerMappingConfiguration.Configure(cfg);
            MealMappingConfiguration.Configure(cfg);
        }
    }
}
