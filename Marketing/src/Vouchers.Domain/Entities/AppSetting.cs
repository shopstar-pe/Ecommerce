using System;
using Vouchers.Domain.Events;

namespace Vouchers.Domain.Entities
{
    public class AppSetting : BaseEntity
    {
        public AppSetting()
        {
        }

        public int Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsReadOnly { get; set; }

        public static class Factory
        {
            /// <summary>
            /// Factory to create the initial instace.
            /// </summary>
            /// <param name="group"></param>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="isReadOnly"></param>
            /// <param name="createdBy"></param>
            /// <returns></returns>
            public static AppSetting Create(
                string group,
                string name,
                string value,
                bool isReadOnly,
                string createdBy)
            {
                var entity = new AppSetting()
                {
                    Group = group,
                    Name = name,
                    Value = value,
                    IsReadOnly = isReadOnly,
                    CreatedBy = createdBy
                };


                // Add the AppSettingCreatedDomainEvent to the domain events collection 
                // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
                entity.AddDomainEvent(new AppSettingCreatedDomainEvent(entity.Id, group, name, value));

                return entity;
            }

        }
    }
}
