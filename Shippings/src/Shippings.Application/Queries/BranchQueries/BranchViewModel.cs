using System;
using System.Collections.Generic;

namespace Shippings.Application.Queries.BranchQueries
{
    public class BranchListViewModel : BranchViewModel
    {

    }

    public class BranchViewModel
    {
        public Guid Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal ReadOnly { get; set; }
    }

}
