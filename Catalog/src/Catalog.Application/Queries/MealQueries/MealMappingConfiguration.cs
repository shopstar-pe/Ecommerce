using System;
using System.Linq;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.MealQueries
{
    public static class MealMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, MealViewModel>();
            cfg.CreateMap<Sku, MealVariantViewModel>();
            cfg.CreateMap<ProductImage, MealImageViewModel>();
            cfg.CreateMap<SkuImage, MealImageViewModel>();
            cfg.CreateMap<SkuAdditionalServicePrice, MealComplementModel>();

            cfg.CreateMap<Product, MealListViewModel>()
                .ForMember(d => d.Variants, opt => opt.MapFrom(src => src.Skus))
                .ForMember(d => d.DefaultImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(x => x.IsPrimary).UrlLinkCatalog));
            
            cfg.CreateMap<PagedResult<Product>, PagedViewModelResult<MealListViewModel>>();
        }
    }
}
