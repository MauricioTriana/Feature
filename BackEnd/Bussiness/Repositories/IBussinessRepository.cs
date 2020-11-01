
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

namespace Bussiness.Repositories
{
    /// <summary>
    /// Interface Bussiness
    /// </summary>
    public interface IBussinessRepository
    {
 
        /// <summary>
        /// Consultar la profesion de un empleado
        /// </summary>  
        /// <param name="cedula">Numero de cedula empleado</param>
        /// <returns>Mensaje de ejecucion correcta</returns>
        string ConsultarProfesionEmpleadoFunction(string cedula);

        /// <summary>
        /// registrar asociacion
        /// </summary>
        /// <param name="newAsociacion">Registro a ingresar</param>
        /// <returns>mensaje con resultado de la operacion</returns>
        string CrearAsociacion(JObject newAsociacion);

        /// <summary>
        /// listar las asociaciones existentes
        /// </summary>
        /// <returns>Lista de asociaciones registradas</returns>
        JArray listarAsociacionesFunction();


    }
}
