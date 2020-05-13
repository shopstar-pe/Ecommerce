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
    public class UpdateCouponCommand : IRequest<CommandResult>
    {
        public int CouponId { get; set; }
        [Required]
        [MaxLength(15)]
        public string Code { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string UtmSource { get; set; }
        public string UtmCampaign { get; set; }

        public ConditionType ConditionType { get; set; }
        /// <summary>
        /// Value discount ( percent, amount )
        /// </summary>
        public decimal Value { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsUnlimited { get; set; }
        public int UsageLimit { get; set; }
        public bool LimitByCustomer { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxOrderAmount { get; set; }

        public int? SellerId { get; set; }

        public class Handler : IRequestHandler<UpdateCouponCommand, CommandResult>
        {
            readonly ICouponRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(ICouponRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var entity = await this._repository.FindFirst(c => c.TenantId.Equals(tenantId) && c.CouponId.Equals(request.CouponId));

                if (entity == null)
                {
                    throw new EntityNotFoundException($"The Resource {request.CouponId} not exists.");
                }

                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.Value = request.Value;

                entity.SetDates(request.StartDate, request.EndDate);
                entity.SetMinMaxOrderValue(request.MinOrderAmount, request.MaxOrderAmount);
                entity.UtmSource = request.UtmSource;
                entity.UtmCampaign = request.UtmCampaign;
                entity.IsUnlimited = request.IsUnlimited;
                entity.LimitByCustomer = request.LimitByCustomer;

                entity.Update(userId);

                this._repository.Update(entity);

                await this._repository.SaveChanges();

                return new CommandResult { };
            }
        }
    }
}
