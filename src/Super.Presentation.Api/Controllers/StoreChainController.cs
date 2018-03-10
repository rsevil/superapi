using MediatR;
using Microsoft.AspNetCore.Mvc;
using Super.Core.Commands;
using Super.Core.Queries;
using Super.Presentation.Api.Models.StoreChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoreChainController : Controller
    {
        private readonly IMediator mediator;

        public StoreChainController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetParams getParams)
        {
            return Ok(
                await mediator.Send(
                    new FindStoreChainPagedQuery(getParams.PageParams)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostParams postParams)
        {
            var id = Guid.NewGuid();

            await mediator.Send(
                new StoreChainCreateCommand(id, postParams.Name));

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutParams putParams)
        {
            await mediator.Send(
                new StoreChainUpdateCommand(putParams.Id, putParams.Name));

            return Ok();
        }
    }
}
