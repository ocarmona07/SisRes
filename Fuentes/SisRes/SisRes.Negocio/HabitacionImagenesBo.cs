namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para imágenes de habitaciones
    /// </summary>
    public class HabitacionImagenesBo
    {
        /// <summary>
        /// Método que almacena una imágen de la habitación
        /// </summary>
        /// <param name="habitacion">Datos de la imagen</param>
        /// <returns>Id de ingreso</returns>
        public int CrearImagenHabitacion(HAB_HabitacionImagenes habitacion)
        {
            return new HabitacionImagenesDa().CrearImagenHabitacion(habitacion);
        }

        /// <summary>
        /// Método que obtiene una imagen de la habitación
        /// </summary>
        /// <param name="idHabitacion">Id de la habitación</param>
        /// <returns>Habitacion</returns>
        public HAB_HabitacionImagenes ObtenerImagenHabitacion(int idHabitacion)
        {
            return new HabitacionImagenesDa().ObtenerImagenHabitacion(idHabitacion);            
        }

        /// <summary>
        /// Método que obtiene todas las imagenes de habitaciones
        /// </summary>
        /// <returns>Lista de habitaciones</returns>
        public List<HAB_HabitacionImagenes> ObtenerHabitacionImagenes()
        {
            return new HabitacionImagenesDa().ObtenerHabitacionImagenes();            
        }

        /// <summary>
        /// Método que actualiza una imagen de la habitación
        /// </summary>
        /// <param name="habitacion">Datos del imagen</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarImagenHabitacion(HAB_HabitacionImagenes habitacion)
        {
            return new HabitacionImagenesDa().ActualizarImagenHabitacion(habitacion);            
        }

        /// <summary>
        /// Método que elimina una imagen de la habitación
        /// </summary>
        /// <param name="idHabitacion">Id del habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarImagenHabitacion(int idHabitacion)
        {
            return new HabitacionImagenesDa().EliminarImagenHabitacion(idHabitacion);            
        }
    }
}
