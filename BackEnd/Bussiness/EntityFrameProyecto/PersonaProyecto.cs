using System;
using System.Collections.Generic;

namespace Bussiness.EntityFrameProyecto
{
    public partial class PersonaProyecto
    {
        public int IdPerPro { get; set; }
        public int IdPersona { get; set; }
        public int IdProyecto { get; set; }
        public long ValorAporta { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
