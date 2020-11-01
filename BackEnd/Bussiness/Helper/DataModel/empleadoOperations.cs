using Bussiness.EntityFrameProyecto;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bussiness.Entities.Appsettings;

namespace PlanesFamiliares.Bussiness.Helper.DataModel
{
    /// <summary>
    /// Operaciones empleado
    /// </summary>
    public static class empleadoOperations
    {

        /// <summary>
        /// Consultar el primer nombre de un integrnate de comunidad
        /// </summary>
        /// <param name="cedula">Numero de empleado a validar</param>
        /// <param name="uris">Url consumo de servicios</param>
        /// <param name="logger">Logger de aplicacion </param>
        /// <param name="cache"></param>
        /// <returns>profesion del empleado</returns>
        public static string ConsultarProfesionEmpleado( string cedula, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            string valorRetorno = string.Empty;
            if (uris != null && logger != null && cache != null)
            {
                using (ProyectosContext db = new ProyectosContext())
                {
                    int empleado = (from item in db.Persona
                                    where item.Cedula == Convert.ToInt64(cedula)
                                    select item.IdPersona).FirstOrDefault();
                    if (empleado != null)
                    {
                        valorRetorno = db.Empleado.Where(x => x.IdPersona == empleado).FirstOrDefault().Profesion;
                    }
                }
            }
            else
            {
                logger.LogCritical("Problemas al leer los parámetros");
            }
            return valorRetorno;
        }
    }
}
