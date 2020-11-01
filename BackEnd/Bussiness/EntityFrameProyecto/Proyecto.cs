using System;
using System.Collections.Generic;

namespace Bussiness.EntityFrameProyecto
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            InverseIdProyectoPadreNavigation = new HashSet<Proyecto>();
            PersonaProyecto = new HashSet<PersonaProyecto>();
        }

        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public string PaisDesarrollo { get; set; }
        public int? IdProyectoPadre { get; set; }
        public int IdAsociacion { get; set; }

        public virtual Asociacion IdAsociacionNavigation { get; set; }
        public virtual Proyecto IdProyectoPadreNavigation { get; set; }
        public virtual ICollection<Proyecto> InverseIdProyectoPadreNavigation { get; set; }
        public virtual ICollection<PersonaProyecto> PersonaProyecto { get; set; }
    }
}
