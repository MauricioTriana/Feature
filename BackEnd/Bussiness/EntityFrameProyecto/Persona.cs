using System;
using System.Collections.Generic;

namespace Bussiness.EntityFrameProyecto
{
    public partial class Persona
    {
        public Persona()
        {
            PersonaProyecto = new HashSet<PersonaProyecto>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public string Direccion { get; set; }
        public int TelContacto { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<PersonaProyecto> PersonaProyecto { get; set; }
    }
}
