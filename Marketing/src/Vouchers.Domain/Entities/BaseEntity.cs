using System;
using System.Collections.Generic;

namespace Vouchers.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.EntityStatus = EntityStatus.Active;
        }

        private List<IDomainEvent> _domainEvents;
        public List<IDomainEvent> DomainEvents => _domainEvents;

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public EntityStatus EntityStatus { get; set; }

        public void Update(string updatedBy)
        {
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = DateTime.UtcNow;
        }

        public void Delete()
        {
            this.EntityStatus = EntityStatus.Deleted;
            this.DeletedOn = DateTime.UtcNow;
        }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }

    public enum EntityStatus
    {
        Active,
        Deleted
    }
}
