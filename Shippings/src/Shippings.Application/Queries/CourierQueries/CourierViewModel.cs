﻿using System;
using System.Collections.Generic;

namespace Shippings.Application.Queries.CourierQueries
{
    public class CourierListViewModel : CourierViewModel
    {

    }

    public class CourierViewModel
    {
        public Guid Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal ReadOnly { get; set; }
    }

}
