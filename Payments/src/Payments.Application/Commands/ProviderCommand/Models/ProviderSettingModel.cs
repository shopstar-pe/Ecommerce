using System;
namespace Payments.Application.Commands.ProviderCommand.Models
{
    public class ProviderSettingModel
    {
        public int ProviderSettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
