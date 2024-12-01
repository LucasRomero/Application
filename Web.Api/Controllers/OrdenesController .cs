using Application.Exceptions;
using Application.Features.Ordenes.Create;
using Application.Features.Ordenes.Delete;
using Application.Features.Ordenes.Get;
using Application.Features.Ordenes.GetById;
using Application.Features.Ordenes.Update;
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
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class OrdenesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdenesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdenesQuery());

            return result.Match(Results.Ok, CustomResults.Problem);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrdenByIdQuery { Id = id });

            return result.Match(Results.Ok, CustomResults.Problem);
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateOrdenRequest request)
        {
            //if (string.IsNullOrEmpty(request.Operacion) || request.Operacion.Length > 1)
            //{
            //    return BadRequest(new { Error = "El Valor de operacion debe contener 'C' por compra o 'V' por venta." });
            //}

            var command = new CreateOrdenCommand
            {
                Cantidad = request.Cantidad,
                ActivoId = request.ActivoId,
                CuentaId = request.CuentaId,
                Operacion = Convert.ToChar(request.Operacion)
            };

            var result = await _mediator.Send(command);

            return result.Match(Results.Created, CustomResults.Problem);
        }

        [HttpPut]
        public async Task<IResult> Update([FromBody] UpdateOrdenRequest request)
        {

            var command = new UpdateOrdenCommand
            {
                EstadoId = request.EstadoId,
                IdOrden = request.IdOrden,
            };

            var result = await _mediator.Send(command);

            return result.Match(Results.Ok, CustomResults.Problem);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOrdenCommand(id));

            return result.Match(Results.NoContent, CustomResults.Problem);
        }

    }
}
