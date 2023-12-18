using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Suscripcion
    {
        public int Id { get; set; }
        public int? SolicitanteId { get; set; }
        public int? EmpresaId { get; set; }

        public virtual Empresa? Empresa { get; set; }
        public virtual Solicitante? Solicitante { get; set; }
    }
}
