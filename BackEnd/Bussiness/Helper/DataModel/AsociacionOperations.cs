using Bussiness.EntityFrameProyecto;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bussiness.Entities.Appsettings;

namespace Bussiness.Helper.DataModel
{
    /// <summary>
    /// Operaciones de la tabla asociacion
    /// </summary>
    public static class AsociacionOperations
    {
        /// <summary>
        /// listar las asociaciones existentes
        /// </summary>
        /// <param name="uris">Url a usar</param>
        /// <param name="logger">Logger de la sesion</param>
        /// <param name="cache">Cache en curso</param>
        /// <returns>Lista de asociaciones registradas</returns>
        public static dynamic listarAsociaciones(IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            using (ProyectosContext db = new ProyectosContext())
            {
                var resultado = (from item in db.Asociacion
                                 orderby item.IdAsociacion ascending
                                 select item);

                var asociaciones = JsonConvert.SerializeObject(resultado);
                return JsonConvert.DeserializeObject<JArray>(asociaciones) ?? new JArray();
            }
        }

        /// <summary>
        /// registrar asociacion
        /// </summary>
        /// <param name="newAsociacion">Registro a ingresar</param>
        /// <param name="uris">Url a usar</param>
        /// <param name="logger">Logger de la sesion</param>
        /// <param name="cache">Cache en curso</param>
        /// <returns>mensaje con resultado de la operacion</returns>
        public static dynamic CrearAsociacionFunction(JObject newAsociacion, IOptions<Uris> uris, ILogger logger, IDistributedCache cache)
        {
            string retorno = "registro fallido";
            Asociacion dataAsociacion = JsonConvert.DeserializeObject<Asociacion>(newAsociacion.ToString());
            using (ProyectosContext db = new ProyectosContext ())
            {
                db.Asociacion.Add(dataAsociacion);
                db.SaveChanges();

                retorno = "registro exitoso" ;
            }
            return retorno;
        }

    }
}
