using System;
using System.Collections.Generic;

namespace Bussiness.EntityFrameProyecto
{
    public partial class Asociacion
    {
        public Asociacion()
        {
            Empleado = new HashSet<Empleado>();
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdAsociacion { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
