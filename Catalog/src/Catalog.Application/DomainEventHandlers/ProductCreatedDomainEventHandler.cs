using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Domain.Events;
using Catalog.Domain.Repositories;
using Catalog.Application.Abstractions;
using System.Collections.Generic;
using Catalog.Messages;

namespace Catalog.Application.DomainEventHandlers
{
    public class ProductCreatedDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        protected readonly IProductRepository _repository;
        protected readonly IBusService _bus;

        public ProductCreatedDomainEventHandler(IProductRepository repository,
            IBusService bus)
        {
            this._repository = repository;
            this._bus = bus;
        }

        public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindProductBySlug(notification.TenantId, notification.SellerId, notification.Slug);

            if (entity != null)
            {
                var messages = new List<ProductCreated>();

                messages.Add(new ProductCreated()
                {
                    ProductId = entity.ProductId,
                    Name = entity.Name,
                    Description = entity.Description,
                    BasePrice = entity.BasePrice,
                    SpecialPrice = entity.SpecialPrice,
                    BrandId = entity.BrandId,
                    BrandName = entity.Brand?.Name,
                    SellerId = entity.SellerId,
                    SellerName = entity.Seller.Name,
                    Slug = entity.Slug
                });

                await this._bus.Publish(Constants.ProductCreated, messages);
            }
        }
    }
}
