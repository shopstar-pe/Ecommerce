using System;
using Catalog.Domain.Entities;

namespace Catalog.Domain.Events
{
    public class AppSettingCreatedDomainEvent : IDomainEvent
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Name { get; }
        public string Value { get; }

        public AppSettingCreatedDomainEvent(int id, string group, string name, string value)
        {
            this.Id = id;
            this.Group = group;
            this.Name = name;
            this.Value = value;
        }

    }
}
