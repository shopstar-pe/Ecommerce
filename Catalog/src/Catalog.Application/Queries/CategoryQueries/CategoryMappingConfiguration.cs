using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.CategoryQueries
{
    public static class CategoryMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Category, CategoryViewModel>();
            cfg.CreateMap<Category, CategoryListViewModel>();
            cfg.CreateMap<PagedResult<Category>, PagedViewModelResult<CategoryListViewModel>>();
        }
    }
}
