using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Core.Data
{
    public interface IPageParams
    {
        int StartIndex { get; }

        int Length { get; }
    }

    public static class IPageParamsExtensions
    {
        public static int GetCurrentPage(this IPageParams @this)
            => @this.StartIndex / @this.Length;
    }
}
