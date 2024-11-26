using Application.Features.Activos.Create;
using Application.Features.Activos.Delete;
using Application.Features.Activos.Get;
using Application.Features.Activos.GetById;
using Application.Features.Ordenes.Create;
using Application.Features.Ordenes.Delete;
using Application.Features.Ordenes.Get;
using Application.Features.Ordenes.GetById;
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
    public class ActivosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordenes = await _mediator.Send(new GetAllActivosQuery());
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orden = await _mediator.Send(new GetActivoByIdQuery { Id = id });
            if (orden == null) return NotFound();

            return Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivoCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteActivoCommand(id));
            return Ok();
        }

    }
}
