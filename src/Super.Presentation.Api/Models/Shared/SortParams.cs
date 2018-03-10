using Super.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Models.Shared
{
    public class SortParams : ISortParams
    {
        public string[] SortBy { get; set; }

        public SortDirs[] SortDir { get; set; }
    }
}
