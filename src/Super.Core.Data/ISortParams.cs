using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data
{
    public interface ISortParams
    {
        string[] SortBy { get; }

        SortDirs[] SortDir { get; }
    }

    public enum SortDirs
    {
        Asc = 0,
        Desc = 1
    }
}
