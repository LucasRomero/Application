using Application.Features.Ordenes.Create;
using Application.Features.Ordenes.Delete;
using Application.Features.Ordenes.Get;
using Application.Features.Ordenes.GetById;
using Application.Features.Ordenes.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

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
        public async Task<IActionResult> GetAll()
        {
            var ordenes = await _mediator.Send(new GetAllOrdenesQuery());
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orden = await _mediator.Send(new GetOrdenByIdQuery { Id = id });
            if (orden == null) return NotFound();

            return Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrdenRequest request)
        {
            if (string.IsNullOrEmpty(request.Operacion) || request.Operacion.Length > 1)
            {
                return BadRequest(new { Error = "El Valor de operacion debe contener 'C' por compra o 'V' por venta." });
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var command = new CreateOrdenCommand
            {
                Cantidad = request.Cantidad,
                ActivoId = request.ActivoId,
                CuentaId = request.CuentaId,
                Operacion = Convert.ToChar(request.Operacion)
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrdenRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var command = new UpdateOrdenCommand
            {
                EstadoId = request.EstadoId,
                IdOrden = request.IdOrden,
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrdenCommand(id));
            return Ok();
        }

    }
}
