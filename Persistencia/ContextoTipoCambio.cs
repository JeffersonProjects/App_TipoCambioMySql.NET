using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ContextoTipoCambio : DbContext
    {
        public ContextoTipoCambio(DbContextOptions<ContextoTipoCambio> options) : base(options) { }

        public DbSet<TipoCambio> TipoCambio { get; set; }
    }
}
