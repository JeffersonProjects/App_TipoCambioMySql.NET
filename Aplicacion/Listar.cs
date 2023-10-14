using Aplicacion.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Listar
    {
        public class ListarTipoCambio : IRequest<List<ListaTipoCambioDto>>
        {

            public class Operador : IRequestHandler<ListarTipoCambio, List<ListaTipoCambioDto>>
            {
                public readonly ContextoTipoCambio _dbContext;
                public Operador(ContextoTipoCambio context)
                {
                    _dbContext = context;
                }

                public async Task<List<ListaTipoCambioDto>> Handle(ListarTipoCambio request, CancellationToken cancellationToken)
                {
                    var tipoCambio = await _dbContext.TipoCambio.ToListAsync();

                    ListaTipoCambioDto tipoCambioLista = null;
                    List<ListaTipoCambioDto> tCambioLista = new List<ListaTipoCambioDto>();

                    foreach (var linea in tipoCambio)
                    {
                        tipoCambioLista = new ListaTipoCambioDto();
                        tipoCambioLista.TipoCambioId = linea.TipoCambioId;
                        tipoCambioLista.MontoTipoCambio = linea.MontoTipoCambio;
                        tipoCambioLista.FechaActualizacion = linea.FechaActualizacion;
                        tCambioLista.Add(tipoCambioLista);
                    }

                    return tCambioLista;
                }
            }

        }
    }
}
