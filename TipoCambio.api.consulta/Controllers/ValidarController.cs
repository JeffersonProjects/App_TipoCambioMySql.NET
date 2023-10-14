using Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace TipoCambio.api.consulta.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValidarController : Controller
    {
        private readonly IMediator _mediator;

        public ValidarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Acceso(Login.LoginProcesa parametro)
        {
            return await _mediator.Send(parametro);
        }

    }
}
