using Super.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Models.Shared
{
    public class PageParams : IPageParams
    {
        public int StartIndex { get; set; }

        public int Length { get; set; }
    }
}
