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
using Catalog.Application.Commands.ProductCommand.Models;
using System.Linq;

namespace Catalog.Application.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public int? BrandId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public List<int> Categories { get; set; }
        public string Description { get; set; }
        public ConditionType? ConditionType { get; set; }
        public ProductType ProductType { get; set; }
        public string Slug { get; set; }
        public int? CollectionId { get; set; }
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

        public int Stock { get; set; }

        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }

        [Required]
        public List<ProductImageModel> Images { get; set; }
        public List<ProductAttributeModel> Attributes { get; set; }
        public List<ProductVariationModel> Variants { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }

        public class Handler : IRequestHandler<CreateProductCommand, CommandResult>
        {
            readonly IProductRepository _repository;
            readonly IUserIdentityService _userIdentityService;
            readonly ISellerRepository _sellerRepository;

            public Handler(IProductRepository repository, IUserIdentityService userIdentityService, ISellerRepository sellerRepository)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
                this._sellerRepository = sellerRepository;
            }

            public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var seller = await this._sellerRepository.FindFirst(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(request.SellerId));

                if (seller == null)
                {
                    throw new EntityNotFoundException($"The Seller {request.Slug} not exists.");
                }

                var currentEntity = await this._repository.FindFirst(c =>
                    c.TenantId.Equals(tenantId)
                    && c.SellerId.Equals(request.SellerId)
                    && c.Name.Equals(request.Name)
                    && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                currentEntity = await this._repository.FindFirst(c =>
                 c.TenantId.Equals(tenantId)
                  && c.SellerId.Equals(request.SellerId)
                  && c.Slug.Equals(request.Slug) && c.EntityStatus != EntityStatus.Deleted);

                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Product Url {request.Slug} has already been taken.");
                }

                var hasVariations = false;
                if (request.Variants != null && request.Variants.Any())
                    hasVariations = true;

                var slug = $"{request.Slug}-{request.SellerId}";
                var entity = Product.Factory.Create(tenantId, seller.SellerId, slug, request.ProductType, request.Name, request.Description,
                    request.BasePrice, request.SpecialPrice, request.BrandId, request.Categories, userId);

                entity.ApplyTaxes = request.ApplyTaxes;
                entity.AllowStorePickup = request.AllowStorePickup;
                entity.AllowHomeDelivery = request.AllowHomeDelivery;
                entity.AllowSaveAndSubscription = request.AllowSaveAndSubscription;
                entity.AllowPurchaseWithoutStock = request.AllowPurchaseWithoutStock;
                entity.AdditionalNoteRequired = request.AdditionalNoteRequired;
                entity.CountryIsoCode = request.CountryIsoCode;
                entity.CurrencyIsoCode = request.CurrencyIsoCode;
                entity.Order = request.Order;
                entity.MetaTitle = request.MetaTitle;
                entity.MetaDescription = request.MetaDescription;
                entity.Keywords = request.Keywords;
                entity.HasVariations = hasVariations;

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

                if (request.Attributes != null)
                {
                    foreach (var item in request.Attributes)
                    {
                        entity.AddAttributes(item.Key, item.Value);
                    }
                }

                if (request.CollectionId.HasValue && request.CollectionId.Value > 0)
                {
                    entity.AssociateToCollection(request.CollectionId.Value);
                }

                // Create Default SKU
                var location = seller.Locations.FirstOrDefault();
                var skus = new List<Sku>();
                if (request.Variants != null && request.Variants.Any())
                {
                    foreach (var item in request.Variants.Where(c => !string.IsNullOrEmpty(c.Name)))
                    {
                        var sku = Sku.Factory.Create(location.LocationId, item.VariantName, item.SKU ?? DateTime.UtcNow.Ticks.ToString(),
                           item.Name,
                           item.BasePrice,
                           item.SpecialPrice,
                           request.Stock,
                           request.Height,
                           request.Length,
                           request.Width,
                           request.Weight,
                           userId);

                        skus.Add(sku);
                    }
                }
                else
                {
                    var sku = Sku.Factory.Create(location.LocationId,
                            "Default",
                            DateTime.UtcNow.Ticks.ToString(),
                           request.Name,
                           request.BasePrice,
                           request.SpecialPrice,
                           request.Stock,
                           request.Height,
                           request.Length,
                           request.Width,
                           request.Weight,
                           userId);

                    skus.Add(sku);

                    entity.HasVariations = false;

                }

                // Set Images, Complements
                foreach (var sku in skus)
                {

                    if (entity.Images != null)
                    {
                        var images = entity.Images.Select(c => new { File = c.UrlLinkOriginal, IsPrimary = c.IsPrimary });

                        foreach (var img in images)
                        {
                            sku.AddImages(img.File, img.IsPrimary);
                        }

                    }

                    entity.AddVariant(sku);
                }


                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.ProductId.ToString() };
            }
        }
    }
}
