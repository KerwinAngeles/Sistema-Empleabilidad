using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class NotificarSolicitante
    {
        public int Id { get; set; }
        public int? SolicitanteId { get; set; }
        public string? Contenido { get; set; }
        public bool? Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Solicitante? Solicitante { get; set; }
    }
}
