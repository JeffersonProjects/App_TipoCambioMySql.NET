using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dto
{
    public class TipoCambioDto
    {
        //public int TipoCambioId { get; set; }
        public decimal MontoTipoCambio { get; set; }
        public decimal MontoOrigen { get; set; }
        public string? MonedaOrigen { get; set; }
        public string? MonedaDestino { get; set; }
        public decimal MontoCambiado { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
    }
}
