﻿using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.JwtGenerador
{
    public interface IJwtGenerador
    {
        string CrearToken(Usuario usuario);
    }
}
