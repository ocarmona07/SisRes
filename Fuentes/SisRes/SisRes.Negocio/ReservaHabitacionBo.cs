using System;
using System.Linq;

namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using System.Data;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Reserva de Habitaciones
    /// </summary>
    public class ReservaHabitacionBo
    {
        /// <summary>
        /// Método que almacena la Reserva de una Habitación
        /// </summary>
        /// <param name="detalleReserva">Datos de la Reserva</param>
        /// <returns>Id de ingreso</returns>
        public int CrearReservaHabitacion(RES_ReservaHabitacion detalleReserva)
        {
            return new ReservaHabitacionDa().CrearReservaHabitacion(detalleReserva);
        }

        /// <summary>
        /// Método que obtiene la Reserva de una Habitación
        /// </summary>
        /// <param name="idReservaHabitacion">Id del detalleReserva</param>
        /// <returns>Reserva de la Habitacion</returns>
        public RES_ReservaHabitacion ObtenerReservaHabitacion(int idReservaHabitacion)
        {
            return new ReservaHabitacionDa().ObtenerReservaHabitacion(idReservaHabitacion);            
        }

        /// <summary>
        /// Método que obtiene todas las Reservas de Habitaciones
        /// </summary>
        /// <returns>Lista de Reservas</returns>
        public List<RES_ReservaHabitacion> ObtenerReservasHabitaciones()
        {
            return new ReservaHabitacionDa().ObtenerReservasHabitaciones();            
        }

        /// <summary>
        /// Método que actualiza la Reserva de una Habitación
        /// </summary>
        /// <param name="detalleReserva">Datos de la Reserva</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarReservaHabitacion(RES_ReservaHabitacion detalleReserva)
        {
            return new ReservaHabitacionDa().ActualizarReservaHabitacion(detalleReserva);            
        }

        /// <summary>
        /// Método que elimina la Reserva de una Habitación
        /// </summary>
        /// <param name="idReservaHabitacion">Id de la Reserva</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarReservaHabitacion(int idReservaHabitacion)
        {
            return new ReservaHabitacionDa().EliminarReservaHabitacion(idReservaHabitacion);            
        }

        public DataTable CargarListaReservas()
        {
            try
            {
                var listaReservas = ObtenerReservasHabitaciones();
                var detalleReservas = new DetalleReservasBo().ObtenerDetallesReservas();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
