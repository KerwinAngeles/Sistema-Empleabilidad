using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Postulacione
    {
        public int Id { get; set; }
        public int VacanteId { get; set; }
        public int SolicitanteId { get; set; }
        public DateTime? FechaPostulacion { get; set; }
        public string? EstadoPostulacion { get; set; }
        public string? Cv { get; set; }
        public int? EmpresaId { get; set; }

        public virtual Empresa? Empresa { get; set; }
        public virtual Solicitante Solicitante { get; set; } = null!;
        public virtual Vacante Vacante { get; set; } = null!;
    }
}
