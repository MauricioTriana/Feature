using System;
using System.Collections.Generic;

namespace Bussiness.EntityFrameProyecto
{
    public partial class Empleado
    {
        public int IdPersona { get; set; }
        public int IdAsociacion { get; set; }
        public string Tipo { get; set; }
        public long? Salario { get; set; }
        public int? NumeroHorasAportadaa { get; set; }
        public int? Edad { get; set; }
        public string Profesion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual Asociacion IdAsociacionNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
