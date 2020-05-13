using System;
using System.Collections.Generic;

namespace CheckOut.Application.Queries.AppSettingQueries
{
    public class AppSettingPaginationViewModel
    {
        public IEnumerable<AppSettingListViewModel> Items { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }

    public class AppSettingListViewModel : AppSettingViewModel
    {
        public int TotalRows { get; set; }
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
