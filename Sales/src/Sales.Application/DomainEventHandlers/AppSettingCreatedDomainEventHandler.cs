using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Domain.Events;
using Sales.Domain.Repositories;

namespace Sales.Application.DomainEventHandlers
{
    public class AppSettingCreatedDomainEventHandler : INotificationHandler<AppSettingCreatedDomainEvent>
    {
        protected readonly IAppSettingRepository _repository;
        
        public AppSettingCreatedDomainEventHandler(IAppSettingRepository repository)
        {
            this._repository = repository;
        }

        public async Task Handle(AppSettingCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindFirst(c => c.Id.Equals(notification.Name));

        }
    }
}
