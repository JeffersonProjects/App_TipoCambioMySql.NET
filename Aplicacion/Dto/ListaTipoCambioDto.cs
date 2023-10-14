using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dto
{
    public class ListaTipoCambioDto
    {
        public int TipoCambioId { get; set; }
        public decimal MontoTipoCambio { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
