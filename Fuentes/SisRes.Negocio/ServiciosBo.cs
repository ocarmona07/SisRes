namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para servicios
    /// </summary>
    public class ServiciosBo
    {
        /// <summary>
        /// Método que almacena un servicio
        /// </summary>
        /// <param name="servicio">Datos del servicio</param>
        /// <returns>Id de ingreso</returns>
        public int CrearServicio(SER_Servicios servicio)
        {
            return new ServiciosDa().CrearServicio(servicio);
        }

        /// <summary>
        /// Método que obtiene un servicio
        /// </summary>
        /// <param name="idServicio">Id del servicio</param>
        /// <returns>Servicio</returns>
        public SER_Servicios ObtenerServicio(int idServicio)
        {
            return new ServiciosDa().ObtenerServicio(idServicio);            
        }

        /// <summary>
        /// Método que obtiene todos los servicios
        /// </summary>
        /// <returns>Lista de servicios</returns>
        public List<SER_Servicios> ObtenerServicios()
        {
            return new ServiciosDa().ObtenerServicios();            
        }

        /// <summary>
        /// Método que actualiza un servicio
        /// </summary>
        /// <param name="servicio">Datos del servicio</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarServicio(SER_Servicios servicio)
        {
            return new ServiciosDa().ActualizarServicio(servicio);            
        }

        /// <summary>
        /// Método que elimina un servicio
        /// </summary>
        /// <param name="idServicio">Id del servicio</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarServicio(int idServicio)
        {
            return new ServiciosDa().EliminarServicio(idServicio);            
        }
    }
}
