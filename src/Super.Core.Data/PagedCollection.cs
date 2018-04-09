using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data
{
    public class PagedCollection<T> : IPagedCollection<T>
    {
        public PagedCollection(IEnumerable<T> data, long totalCount, int currentPage)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            TotalRecords = totalCount;
            CurrentPage = currentPage;
        }

        public IEnumerable<T> Data { get; }
        public long TotalRecords { get; }
        public int CurrentPage { get; }
    }
}
