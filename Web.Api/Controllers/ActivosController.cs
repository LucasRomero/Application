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
    [Authorize(Policy = "AdminPolicy")]
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
        public async Task<IActionResult> GetAll()
        {
            var activos = await _mediator.Send(new GetAllActivosQuery());
            return Ok(activos);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var activo = await _mediator.Send(new GetActivoByIdQuery { Id = id });
            if (activo == null) return NotFound();

            return Ok(activo);
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
