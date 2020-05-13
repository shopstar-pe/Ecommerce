using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shippings.Domain.Repositories;

namespace Shippings.Application.Queries.AppSettingQueries
{
    public class AppSettingDetailQuery : IRequest<AppSettingViewModel>
    {
        public Guid Id { get; set; }
        
        public class Handler : IRequestHandler<AppSettingDetailQuery, AppSettingViewModel>
        {
            protected readonly IAppSettingRepository _repository;
            protected readonly IMapper _mapper;

            public Handler(IAppSettingRepository repository, IMapper mapper)
            {
                this._repository = repository;
                this._mapper = mapper;
            }

            public async Task<AppSettingViewModel> Handle(AppSettingDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = this._repository.FindFirst(c => c.Id.Equals(request.Id) && c.EntityStatus != Domain.Entities.EntityStatus.Deleted);

                return this._mapper.Map<AppSettingViewModel>(entity);
            }
        }
    }
}
