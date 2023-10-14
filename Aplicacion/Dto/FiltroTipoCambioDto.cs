using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dto
{
    public class FiltroTipoCambioDto
    {
        public decimal montoOrigen { get; set; }
        public string? monedaOrigen { get; set; }
        public string? monedaDestino { get; set; }
    }
}
