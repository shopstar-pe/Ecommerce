using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.AppSettingQueries
{
    public class AppSettingListQuery : IRequest<PagedViewModelResult<AppSettingListViewModel>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 20;
        public string SortType { get; set; }

        public class Handler : IRequestHandler<AppSettingListQuery, PagedViewModelResult<AppSettingListViewModel>>
        {
            protected readonly IAppSettingRepository _repository;
            protected readonly IMapper _mapper;

            public Handler(IAppSettingRepository repository, IMapper mapper)
            {
                this._repository = repository;
                this._mapper = mapper;
            }

            public async Task<PagedViewModelResult<AppSettingListViewModel>> Handle(AppSettingListQuery request, CancellationToken cancellationToken)
            {
                var entities = this._repository.FindPaged(c => c.EntityStatus != Domain.Entities.EntityStatus.Deleted, request.Page, request.PageSize, c => c.CreatedOn, request.SortType);

                return this._mapper.Map<PagedViewModelResult<AppSettingListViewModel>>(entities);
            }
        }
    }
}
