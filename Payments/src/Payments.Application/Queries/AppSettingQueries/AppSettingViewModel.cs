using System;
using System.Collections.Generic;

namespace Payments.Application.Queries.AppSettingQueries
{
    
    public class AppSettingListViewModel : AppSettingViewModel
    {
        
    }

    public class AppSettingViewModel
    {
        public Guid Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal ReadOnly { get; set; }
    }

}
