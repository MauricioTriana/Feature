using Bussiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Bussiness.Controllers
{
    /// <summary>
    /// Controlador Bussiness
    /// </summary>
    public class BussinessController : ControllerBase
    {
        #region Propiedades

        private readonly IBussinessRepository _bussinessRepository;
        private readonly IDistributedCache cache;
        private readonly IMemoryCache cacheM;

        #endregion

        #region Constructor

        /// <summary>
        /// Clase constructora.
        /// </summary>
        /// <param name="bussinessRepository"></param>
        /// <param name="cache"></param>
        /// <param name="cacheM"></param>
        public BussinessController(IBussinessRepository bussinessRepository, IDistributedCache cache, IMemoryCache cacheM)
        {
            _bussinessRepository = bussinessRepository;
            this.cache = cache;
            this.cacheM = cacheM;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// consulta la profesion de un empleado
        /// </summary>
        /// <param name="cedula">numero de cedula del empleado</param>
        /// <returns>la profesion del empleado</returns>
        [HttpGet]
        [Route("/api/Bussiness/ConsultarNombreCompletoIntegante/{cedula}")]
        public dynamic ConsultarProfesionEmpleadoFunction(string cedula)
        {
            if (!String.IsNullOrEmpty(cedula))
            {
                return _bussinessRepository.ConsultarProfesionEmpleadoFunction(cedula);
            }
            return string.Empty;
        }

        /// <summary>
        /// registrar asociacion
        /// </summary>
        /// <param name="newAsociacion">Registro a ingresar</param>
        /// <returns>mensaje con resultado de la operacion</returns>
        [HttpPost]
        [Route("/api/Bussiness/CrearAsociacion")]
        public dynamic CrearAsociacion([FromBody] JObject newAsociacion)
        {
            if (newAsociacion != null)
            {
                return _bussinessRepository.CrearAsociacion(newAsociacion);
            }
            return null;
        }

        /// <summary>
        /// Listar Asociaciones
        /// </summary>
        /// <returns>la profesion del empleado</returns>
        [HttpGet]
        [Route("/api/Bussiness/listarAsociaciones/")]
        public dynamic listarAsociacionesFunction()
        {
            return _bussinessRepository.listarAsociacionesFunction();
        }
        #endregion
    }
}
