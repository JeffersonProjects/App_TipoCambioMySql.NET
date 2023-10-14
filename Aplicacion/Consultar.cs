using Aplicacion.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Consultar
    {
        public class ConsultarTipoCambio : IRequest<TipoCambioDto>
        {
            public decimal MontoOrigen { get; set; }
            public string? MonedaOrigen { get; set; }
            public string? MonedaDestino { get; set; }
        }

        public class Operador : IRequestHandler<ConsultarTipoCambio, TipoCambioDto>
        {
            public readonly ContextoTipoCambio _dbContext;

            public Operador(ContextoTipoCambio context)
            {
                _dbContext = context;
            }

            public async Task<TipoCambioDto> Handle(ConsultarTipoCambio request, CancellationToken cancellationToken)
            {
                var tipoCambio = await _dbContext.TipoCambio.ToListAsync();

                decimal valorTC = 0;
                decimal valorCambiado = 0;

                foreach (var linea in tipoCambio)
                {
                    valorTC = linea.MontoTipoCambio;
                }

                // Si Moneda Origen el Soles
                if(request.MonedaOrigen == "PEN" && request.MonedaDestino == "USD")
                {
                    valorCambiado = request.MontoOrigen * valorTC;
                }

                // Si Moneda Origen es Dolares
                if (request.MonedaOrigen == "USD" && request.MonedaDestino == "PEN")
                {
                    valorCambiado = request.MontoOrigen / valorTC;
                }

                // Devolver el resultado
                return new TipoCambioDto
                {
                    MontoTipoCambio = decimal.Round(valorTC, 2, MidpointRounding.AwayFromZero),
                    MontoOrigen = request.MontoOrigen,
                    MonedaOrigen = request.MonedaOrigen,
                    MonedaDestino = request.MonedaDestino,
                    MontoCambiado = decimal.Round(valorCambiado, 2, MidpointRounding.AwayFromZero)

                };

            }
        }
    }
}
