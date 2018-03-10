using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super.Core.Data;
using Super.Presentation.Api.Models.Shared;

namespace Super.Presentation.Api.Models.Store
{
    public class GetParams
    {
        public Guid ChainId { get; set; }
        public PageParams PageParams { get; set; }
    }
}
