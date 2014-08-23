namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Tipos de Habitaciones
    /// </summary>
    public class TipoHabitacionBo
    {
        /// <summary>
        /// Método que almacena un Tipo de Habitación
        /// </summary>
        /// <param name="tipoHabitacion">Datos del Tipo de Habitacion</param>
        /// <returns>Id de ingreso</returns>
        public int CrearTipoHabitacion(HAB_TipoHabitacion tipoHabitacion)
        {
            return new TipoHabitacionDa().CrearTipoHabitacion(tipoHabitacion);
        }

        /// <summary>
        /// Método que obtiene un Tipo de Habitación
        /// </summary>
        /// <param name="idTipoHabitacion">Id del Tipo de Habitación</param>
        /// <returns>TipoHabitacion</returns>
        public HAB_TipoHabitacion ObtenerTipoHabitacion(int idTipoHabitacion)
        {
            return new TipoHabitacionDa().ObtenerTipoHabitacion(idTipoHabitacion);            
        }

        /// <summary>
        /// Método que obtiene todos los Tipos de Habitaciones
        /// </summary>
        /// <returns>Lista de Tipo de Habitaciones</returns>
        public List<HAB_TipoHabitacion> ObtenerTipoHabitacion()
        {
            return new TipoHabitacionDa().ObtenerTiposHabitaciones();            
        }

        /// <summary>
        /// Método que actualiza un Tipo de Habitación
        /// </summary>
        /// <param name="tipoHabitacion">Datos del Tipo de Habitación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarTipoHabitacion(HAB_TipoHabitacion tipoHabitacion)
        {
            return new TipoHabitacionDa().ActualizarTipoHabitacion(tipoHabitacion);            
        }

        /// <summary>
        /// Método que elimina un Tipo de Habitación
        /// </summary>
        /// <param name="idTipoHabitacion">Id del Tipo de Habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarTipoHabitacion(int idTipoHabitacion)
        {
            return new TipoHabitacionDa().EliminarTipoHabitacion(idTipoHabitacion);            
        }
    }
}
