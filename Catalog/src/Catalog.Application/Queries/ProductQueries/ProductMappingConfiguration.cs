using System;
using System.Linq;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.ProductQueries
{
    public static class ProductMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductViewModel>();
            cfg.CreateMap<Sku, ProductVariantViewModel>();
            cfg.CreateMap<ProductImage, ProductImageViewModel>();
            cfg.CreateMap<SkuImage, ProductImageViewModel>();

            cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();

            cfg.CreateMap<Product, ProductListViewModel>()
                .ForMember(d => d.Variants, opt => opt.MapFrom(src => src.Skus))
                .ForMember(d => d.DefaultImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(x => x.IsPrimary).UrlLinkCatalog))
                .ForMember(d => d.Stock, opt => opt.MapFrom(src => src.Skus.FirstOrDefault().Stock))
                .ForMember(d => d.Height, opt => opt.MapFrom(src => src.Skus.FirstOrDefault().Height))
                .ForMember(d => d.Length, opt => opt.MapFrom(src => src.Skus.FirstOrDefault().Length))
                .ForMember(d => d.Width, opt => opt.MapFrom(src => src.Skus.FirstOrDefault().Width))
                .ForMember(d => d.Weight, opt => opt.MapFrom(src => src.Skus.FirstOrDefault().Weight));

            cfg.CreateMap<PagedResult<Product>, PagedViewModelResult<ProductListViewModel>>();
        }
    }
}
