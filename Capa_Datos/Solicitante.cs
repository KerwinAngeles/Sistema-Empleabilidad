using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Solicitante
    {
        public Solicitante()
        {
            NotificarSolicitantes = new HashSet<NotificarSolicitante>();
            Postulaciones = new HashSet<Postulacione>();
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<NotificarSolicitante> NotificarSolicitantes { get; set; }
        public virtual ICollection<Postulacione> Postulaciones { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
