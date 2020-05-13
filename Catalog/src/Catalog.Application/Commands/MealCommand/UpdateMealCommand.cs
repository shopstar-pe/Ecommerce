using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Catalog.Domain.Repositories;
using System.Collections.Generic;
using Catalog.Application.Commands.MealCommand.Models;
using System.Linq;

namespace Catalog.Application.Commands.MealCommand
{
    public class UpdateMealCommand : IRequest<CommandResult>
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public bool AllowStorePickup { get; set; }
        public bool AllowHomeDelivery { get; set; }
        public bool AllowSaveAndSubscription { get; set; }
        public bool AllowPurchaseWithoutStock { get; set; }
        public bool ApplyTaxes { get; set; }
        public bool AdditionalNoteRequired { get; set; }

        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }

        public int Order { get; set; }
        [Required]
        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }

        [Required]
        public List<MealImageModel> Images { get; set; }
        public List<MealAttributeModel> Attributes { get; set; }
        public List<MealVariationModel> Variants { get; set; }
        public List<MealNewComplementModel> Complements { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }

        public class Handler : IRequestHandler<UpdateMealCommand, CommandResult>
        {
            readonly IProductRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IProductRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindProductById(tenantId, request.ProductId);

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.ProductId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                
                entity.ApplyTaxes = request.ApplyTaxes;
                entity.AllowStorePickup = request.AllowStorePickup;
                entity.AllowHomeDelivery = request.AllowHomeDelivery;
                entity.AllowSaveAndSubscription = request.AllowSaveAndSubscription;
                entity.AllowPurchaseWithoutStock = request.AllowPurchaseWithoutStock;
                entity.AdditionalNoteRequired = request.AdditionalNoteRequired;
                entity.CountryIsoCode = request.CountryIsoCode;
                entity.CurrencyIsoCode = request.CurrencyIsoCode;

                entity.SetPrices(request.BasePrice, request.SpecialPrice);

                entity.Order = request.Order;
                entity.MetaTitle = request.MetaTitle;
                entity.MetaDescription = request.MetaDescription;
                entity.Keywords = request.Keywords;

                entity.ClearImages();

                if (request.Images != null && request.Images.Count > 0)
                {
                    var hasPrincipal = request.Images.Any(c => c.IsPrincipal);

                    if (!hasPrincipal)
                        request.Images.ElementAt(0).IsPrincipal = true;

                    foreach (var i in request.Images)
                    {
                        if (!string.IsNullOrEmpty(i.Url))
                            entity.AddImages(i.Url, i.IsPrincipal);
                    }
                }

                entity.ClearAttributes();

                if (request.Attributes != null)
                {
                    foreach (var item in request.Attributes)
                    {
                        entity.AddAttributes(item.Key, item.Value);
                    }
                }

                // Default Location
                var locationId = entity.Skus.FirstOrDefault().Inventories.FirstOrDefault().LocationId;

                if (!entity.HasVariations && request.Variants.Any())
                {
                    entity.HasVariations = true;
                    entity.ClearSkus();
                }

                if (entity.Skus != null && entity.Skus.Any())
                {
                    foreach (var item in entity.Skus)
                    {
                        var variant = request.Variants.FirstOrDefault(c => c.SkuId.Equals(item.SkuId));

                        if (variant != null)
                        {
                            item.VariantName = variant.VariantName;
                            item.SKU = variant.SKU;
                            item.SetPrices(variant.BasePrice, variant.SpecialPrice);
                            item.Name = variant.Name;
                            item.Stock = variant.Stock;
                            item.Height = variant.Height;
                            item.Length = variant.Length;
                            item.Width = variant.Width;
                            item.Weight = variant.Height;
                            item.Update(userId);
                        }
                    }
                }

                // Create New Skus
                if (request.Variants != null) {
                    foreach (var item in request.Variants.Where(c=> !entity.Skus.Select(x=> x.SkuId).Contains(c.SkuId)))
                    {
                        var sku = Sku.Factory.Create(locationId, item.VariantName, item.SKU ?? DateTime.UtcNow.Ticks.ToString(),
                          item.Name,
                          item.BasePrice,
                          item.SpecialPrice,
                          item.Stock,
                          item.Height,
                          item.Length,
                          item.Width,
                          item.Weight,
                          userId);

                        entity.AddVariant(sku);
                    }
                }

                // Set Images, Complements
                foreach (var sku in entity.Skus)
                {
                    if (entity.Images != null)
                    {
                        var images = entity.Images.Select(c => new { File = c.UrlLinkOriginal, IsPrimary = c.IsPrimary });

                        sku.ClearImages();

                        foreach (var img in images)
                        {
                            sku.AddImages(img.File, img.IsPrimary);
                        }

                    }

                    if (request.Complements != null)
                    {
                        sku.ClearAdditionalServices();
                        foreach (var complement in request.Complements)
                        {
                            sku.AddAdditionalServices(complement.PriceId);
                        }
                    }
                }

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
