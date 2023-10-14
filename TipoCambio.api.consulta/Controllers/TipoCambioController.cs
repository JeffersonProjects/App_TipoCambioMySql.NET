using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion;
using Modelo;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.Dto;

namespace TipoCambio.api.consulta.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoCambioController : Controller
    {
        private readonly IMediator _mediator;
        public TipoCambioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaTipoCambioDto>>> Listar()
        {
            return await _mediator.Send(new Listar.ListarTipoCambio());
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<TipoCambioDto>> CosultarTipoCambio( FiltroTipoCambioDto objData)  //[FromQuery]
        {
            return await _mediator.Send(new Consultar.ConsultarTipoCambio { MontoOrigen = objData.montoOrigen, MonedaOrigen = objData.monedaOrigen, MonedaDestino = objData.monedaDestino });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> Crear([FromBody] Nuevo.NuevoTipoCambio objData)
        {
            objData.FechaActualizacion = DateTime.Now;
            return await _mediator.Send(objData);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<int>> Actualizar([FromBody] Actualizar.ActualizarTipoCambio objData)
        {
            objData.FechaActualizacion = DateTime.Now;
            return await _mediator.Send(objData);
        }

    }
}
