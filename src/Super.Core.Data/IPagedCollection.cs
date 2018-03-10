using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data
{
    public interface IPagedCollection<out T>
    {
        IEnumerable<T> Data { get; }
        long TotalRecords { get; }
        int CurrentPage { get; }
    }
}
