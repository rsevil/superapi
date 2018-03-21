using MediatR;
using Microsoft.AspNetCore.Mvc;
using Super.Core.Commands;
using Super.Core.Queries;
using Super.Presentation.Api.Models.Store;
using System;
using System.Threading.Tasks;

namespace Super.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly IMediator mediator;

        public StoreController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetParams getParams)
        {
            return Ok(await mediator.Send(
                new FindStoresByChainIdQuery(getParams.ChainId, getParams.PageParams)));
        }

        [HttpGet(nameof(Detail))]
        public async Task<IActionResult> Detail(GetDetailParams getDetailParams)
        {
            return Ok(await mediator.Send(
                new FindStoresByIdQuery(getDetailParams.Id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostParams postParams)
        {
            var id = Guid.NewGuid();

            await mediator.Send(
                new StoreCreateCommand(
                    id, postParams.StoreChainId, postParams.Name,
                    postParams.Latitude, postParams.Longitude, postParams.Address));

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutParams putParams)
        {
            await mediator.Send(
                new StoreUpdateCommand(
                    putParams.Id, putParams.Name,
                    putParams.Latitude, putParams.Longitude, putParams.Address));

            return Ok();
        }
    }
}
