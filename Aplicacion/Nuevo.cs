using MediatR;
using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Nuevo
    {
        public class NuevoTipoCambio : IRequest
        {
            public decimal MontoTipoCambio { get; set; }
            public DateTime? FechaActualizacion { get; set; }

        }

        public class Operador : IRequestHandler<NuevoTipoCambio>
        {
            public readonly ContextoTipoCambio _dbContext;
            public Operador(ContextoTipoCambio context)
            {
                _dbContext = context;
            }

            public async Task<Unit> Handle(NuevoTipoCambio request, CancellationToken cancellationToken)
            {
                var tipoCambio = new TipoCambio
                {
                    MontoTipoCambio = request.MontoTipoCambio,
                    FechaActualizacion = request.FechaActualizacion
                };

                _dbContext.TipoCambio.Add(tipoCambio);

                var valor = await _dbContext.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el tipo de cambio");
            }

        }

    }
}
