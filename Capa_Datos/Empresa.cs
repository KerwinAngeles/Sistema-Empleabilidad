using System;
using System.Collections.Generic;

namespace Capa_Datos
{
    public partial class Empresa
    {
        public Empresa()
        {
            Notificars = new HashSet<Notificar>();
            Postulaciones = new HashSet<Postulacione>();
            Suscripcions = new HashSet<Suscripcion>();
            Vacantes = new HashSet<Vacante>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Notificar> Notificars { get; set; }
        public virtual ICollection<Postulacione> Postulaciones { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
