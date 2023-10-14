using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Actualizar
    {
        public class ActualizarTipoCambio : IRequest<int>
        {
            public int TipoCambioId { get; set; }
            public decimal MontoTipoCambio { get; set; }
            public DateTime? FechaActualizacion { get; set; }
        }

        public class Operador : IRequestHandler<ActualizarTipoCambio, int>
        {
            public readonly ContextoTipoCambio _dbContext;

            public Operador(ContextoTipoCambio context)
            {
                _dbContext = context;
            }

            public async Task<int> Handle(ActualizarTipoCambio request, CancellationToken cancellationToken)
            {
                var tipoCambio = await _dbContext.TipoCambio.FindAsync(request.TipoCambioId);

                if (tipoCambio == null)
                {
                    throw new Exception("No se pudo encontrar el tipo de cambio");
                }

                tipoCambio.MontoTipoCambio = request.MontoTipoCambio;
                tipoCambio.FechaActualizacion = request.FechaActualizacion;

                var rpta = await _dbContext.SaveChangesAsync();

                if (rpta >= 0)
                {
                    return rpta;
                }

                throw new Exception("Se ha presentado errores al actualizar el tipo de cambio");

            }

        }
    }
}
