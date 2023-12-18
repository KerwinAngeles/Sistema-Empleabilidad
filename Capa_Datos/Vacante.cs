using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Vacante
    {
        public Vacante()
        {
            Postulaciones = new HashSet<Postulacione>();
        }

        public int VacanteId { get; set; }
        public int? EmpresaId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaPublicacion { get; set; }
        public bool? PlazaOcupada { get; set; }

        public virtual Empresa? Empresa { get; set; }
        public virtual ICollection<Postulacione> Postulaciones { get; set; }
    }
}
