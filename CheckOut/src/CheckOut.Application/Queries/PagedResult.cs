using System;
using System.Collections.Generic;
using CheckOut.Domain.Paging;

namespace CheckOut.Application.Queries
{
    public abstract class PagedViewModelResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedViewModelResult<T> : PagedViewModelResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedViewModelResult()
        {
            Results = new List<T>();
        }
    }
}
