using Application.Exceptions;
using Application.Features.Activos.Create;
using Application.Features.Activos.Delete;
using Application.Features.Activos.Get;
using Application.Features.Activos.GetById;
using Application.Features.Ordenes.Create;
using Application.Features.Ordenes.Delete;
using Application.Features.Ordenes.Get;
using Application.Features.Ordenes.GetById;
using Core.Entities;
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
    public class EstadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEstadosQuery());

            return result.Match(Results.Ok, CustomResults.Problem);
        }

    }
}
