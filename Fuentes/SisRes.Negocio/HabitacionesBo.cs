﻿namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using System.Linq;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para habitaciones
    /// </summary>
    public class HabitacionesBo
    {
        /// <summary>
        /// Método que almacena una habitación
        /// </summary>
        /// <param name="habitacion">Datos de la habitación</param>
        /// <returns>Id de ingreso</returns>
        public int CrearHabitacion(HAB_Habitaciones habitacion)
        {
            return new HabitacionesDa().CrearHabitacion(habitacion);
        }

        /// <summary>
        /// Método que obtiene una habitación
        /// </summary>
        /// <param name="idHabitacion">Id de la habitación</param>
        /// <returns>Habitacion</returns>
        public HAB_Habitaciones ObtenerHabitacion(int idHabitacion)
        {
            return new HabitacionesDa().ObtenerHabitacion(idHabitacion);
        }

        /// <summary>
        /// Método que obtiene todas las habitaciones
        /// </summary>
        /// <returns>Lista de habitaciones</returns>
        public List<HAB_Habitaciones> ObtenerHabitaciones()
        {
            return new HabitacionesDa().ObtenerHabitaciones();
        }

        /// <summary>
        /// Método que actualiza una habitación
        /// </summary>
        /// <param name="habitacion">Datos del habitacion</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarHabitacion(HAB_Habitaciones habitacion)
        {
            return new HabitacionesDa().ActualizarHabitacion(habitacion);
        }

        /// <summary>
        /// Método que elimina una habitación
        /// </summary>
        /// <param name="idHabitacion">Id del habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarHabitacion(int idHabitacion)
        {
            return new HabitacionesDa().EliminarHabitacion(idHabitacion);
        }

        /// <summary>
        /// Método que retorna una lista de habitaciones
        /// </summary>
        /// <returns>Lista numérica de Habitaciones</returns>
        public List<HAB_Habitaciones> ListaHabitaciones(int tipoHabitacion)
        {
            return ObtenerHabitaciones().Where(hab => tipoHabitacion.Equals(hab.IdTipoHabitacion) && true.Equals(hab.Disponible)).ToList();
        }
    }
}
