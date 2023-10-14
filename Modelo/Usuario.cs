using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Token { get; set; }
        public string? Email { get; set; }
    }
}
