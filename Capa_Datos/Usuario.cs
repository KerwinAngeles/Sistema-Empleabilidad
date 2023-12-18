using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Usuario
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Estado { get; set; }
        public string? TipoCuenta { get; set; }
        public int Id { get; set; }
    }
}
