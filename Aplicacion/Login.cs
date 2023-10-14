using Aplicacion.JwtGenerador;
using MediatR;
using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class Login
    {
        public class LoginProcesa : IRequest<Usuario>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Operador : IRequestHandler<LoginProcesa, Usuario>
        {
            private readonly IJwtGenerador _jwtGenerador;
            public readonly ContextoTipoCambio _dbContext;
            public Operador(IJwtGenerador jwtGenerador, ContextoTipoCambio context)
            {
                _jwtGenerador = jwtGenerador;
                _dbContext = context;
            }

            public async Task<Usuario> Handle(LoginProcesa request, CancellationToken cancellationToken)
            {
                //var usuario = await _dbContext.Usuario.Where(p => p.Email == request.Email).FirstOrDefaultAsync();

                var usuario = new Usuario
                {
                    NombreUsuario = "jperez",
                    Email = request.Email,
                    Token = ""

                };

                if (usuario == null)
                {                    
                    throw new Exception("No autorizado");
                }

                return new Usuario
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    Token = _jwtGenerador.CrearToken(usuario)

                };

            }
        }
    }
}
