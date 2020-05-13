using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vouchers.Application.Abstractions;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Exceptions;
using Vouchers.Domain.Repositories;

namespace Vouchers.Application.Commands.CouponCommand
{
    public class CreateCouponCommand : IRequest<CommandResult>
    {
        [Required]
        [MaxLength(15)]
        public string Code { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public ConditionType ConditionType { get; set; }
        [Required]
        public decimal Value { get; set; }

        public string Description { get; set; }
        public string UtmSource { get; set; }
        public string UtmCampaign { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsUnlimited { get; set; }
        public int UsageLimit { get; set; }
        public bool LimitByCustomer { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxOrderAmount { get; set; }

        public int? SellerId { get; set; }

        public class Handler : IRequestHandler<CreateCouponCommand, CommandResult>
        {
            readonly ICouponRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICouponRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = Coupon.Factory.Create(tenantId, request.SellerId, request.Code, request.Name, request.Description, request.ConditionType, request.Value, userId);

                var currentEntity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.Code.Equals(request.Code) && c.EntityStatus != EntityStatus.Deleted);
                if (currentEntity != null)
                {
                    throw new EntityAlreadyExistException($"The Resource {request.Name} already exists.");
                }

                entity.SetDates(request.StartDate, request.EndDate);
                entity.SetMinMaxOrderValue(request.MinOrderAmount, request.MaxOrderAmount);
                entity.UtmSource = request.UtmSource;
                entity.UtmCampaign = request.UtmCampaign;
                entity.IsUnlimited = request.IsUnlimited;
                entity.LimitByCustomer = request.LimitByCustomer;

                this._repository.Add(entity);

                await this._repository.SaveChanges();

                return new CommandResult { Id = entity.CouponId.ToString() };
            }
        }
    }
}
