namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Reserva de Habitación
    /// </summary>
    public class ReservaHabitacionDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public ReservaHabitacionDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena una Reserva de Habitación
        /// </summary>
        /// <param name="reservaHabitacion">Datos de la Habitación</param>
        /// <returns>Id de ingreso</returns>
        public int CrearReservaHabitacion(RES_ReservaHabitacion reservaHabitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.RES_ReservaHabitacion.AddObject(reservaHabitacion);
                idRetorno = _sisResEntities.SaveChanges();
                _sisResEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }

        /// <summary>
        /// Método que obtiene una Reserva de Habitación
        /// </summary>
        /// <param name="idReserva">Id de la reserva</param>
        /// <returns>Reserva de Habitación</returns>
        public RES_ReservaHabitacion ObtenerReservaHabitacion(int idReserva)
        {
            var retorno = new RES_ReservaHabitacion();
            try
            {
                retorno = _sisResEntities.RES_ReservaHabitacion.Single(tc => tc.IdReserva == idReserva);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todas las Reservas de Habitaciones
        /// </summary>
        /// <returns>Lista de Reservas</returns>
        public List<RES_ReservaHabitacion> ObtenerReservasHabitaciones()
        {
            var listaRetorno = new List<RES_ReservaHabitacion>();
            try
            {
                listaRetorno = _sisResEntities.RES_ReservaHabitacion.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza una Reserva de Habitación
        /// </summary>
        /// <param name="reservaHabitacion">Datos de la Habitación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarReservaHabitacion(RES_ReservaHabitacion reservaHabitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.RES_ReservaHabitacion.Attach(reservaHabitacion);
                _sisResEntities.ObjectStateManager.ChangeObjectState(reservaHabitacion, EntityState.Modified);
                idRetorno = _sisResEntities.SaveChanges();
                _sisResEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }

        /// <summary>
        /// Método que elimina una Reserva de Habitación
        /// </summary>
        /// <param name="idReserva">Id de la Reserva</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarReservaHabitacion(int idReserva)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.RES_ReservaHabitacion", "IdHabitacion", idReserva), out objetoEliminar);
                _sisResEntities.DeleteObject(objetoEliminar);
                idRetorno = _sisResEntities.SaveChanges();
                _sisResEntities.Dispose();
                return idRetorno;
            }
            catch (Exception)
            {
                return idRetorno;
            }
        }
    }
}
