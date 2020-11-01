using Bussiness.Helper.DataModel;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlanesFamiliares.Bussiness.Helper;
using PlanesFamiliares.Bussiness.Helper.DataModel;
using System;
using static Bussiness.Entities.Appsettings;

namespace Bussiness.Repositories
{
    /// <summary>
    /// Respositorio para Bussiness
    /// </summary>
    public class BussinessRepository : IBussinessRepository
    {
        private readonly IOptions<Uris> _uris;
        private readonly IDistributedCache cache;
        private readonly ILogger<BussinessRepository> logger;

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="uris"></param>
        /// <param name="cache"></param>
        public BussinessRepository(ILogger<BussinessRepository> logger, IOptions<Uris> uris, IDistributedCache cache)
        {
            _uris = uris;
            this.logger = logger;
            this.cache = cache;
        }


        #region Metodos

        /// <summary>
        /// Consultar el nombre completo de un integrante de la comunidad
        /// </summary>
        /// <param name="cedula">empleado a consultar</param>
        /// <returns>Empleado a consultar</returns>
        public string ConsultarProfesionEmpleadoFunction( string cedula) => empleadoOperations.ConsultarProfesionEmpleado( cedula, _uris, logger, cache);

        /// <summary>
        /// registrar asociacion
        /// </summary>
        /// <param name="newAsociacion">Registro a ingresar</param>
        /// <returns>mensaje con resultado de la operacion</returns>
        public string CrearAsociacion(JObject newAsociacion) => AsociacionOperations.CrearAsociacionFunction(newAsociacion, _uris, logger, cache);

        /// <summary>
        /// listar las asociaciones existentes
        /// </summary>
        /// <returns>Lista de asociaciones registradas</returns>
        public JArray listarAsociacionesFunction() => AsociacionOperations.listarAsociaciones(_uris, logger, cache);


        #endregion Metodos




    }
}
