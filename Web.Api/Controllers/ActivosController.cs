using Application.Exceptions;
using Application.Features.Activos.Create;
using Application.Features.Activos.Delete;
using Application.Features.Activos.Get;
using Application.Features.Activos.GetById;
using Application.Features.Ordenes.Create;
using Application.Features.Ordenes.Delete;
using Application.Features.Ordenes.Get;
using Application.Features.Ordenes.GetById;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Web.Api.Extension;

namespace Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ActivosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllActivosQuery());
            return result.Match(Results.Ok, CustomResults.Problem);
        }

        [HttpGet("GetById")]
        public async Task<IResult> GetById([FromQuery] int id)
        {
            Result<ActivoResponse> result = await _mediator.Send(new GetActivoByIdQuery { Id = id });

            return result.Match(Results.Ok, CustomResults.Problem);
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateActivoRequest request)
        {

            var command = new CreateActivoCommand
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Precio = request.Precio,
                Ticker = request.Ticker,
                TipoId = request.TipoId
            };

             Result<int> result = await _mediator.Send(command);

            return result.Match(
                id => Results.Created($"/activos/{id}", new { id }),
                CustomResults.Problem
            );
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            Result result = await _mediator.Send(new DeleteActivoCommand(id));

            return result.Match(Results.NoContent, CustomResults.Problem);
        }

    }
}
