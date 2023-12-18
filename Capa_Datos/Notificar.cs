using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Notificar
    {
        public int Id { get; set; }
        public int? EmpresaId { get; set; }
        public string? Contenido { get; set; }
        public bool? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Empresa? Empresa { get; set; }
    }
}
