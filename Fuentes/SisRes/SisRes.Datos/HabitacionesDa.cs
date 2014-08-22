namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Habitaciones
    /// </summary>
    public class HabitacionesDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public HabitacionesDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena una Habitación
        /// </summary>
        /// <param name="habitacion">Datos de la Habitación</param>
        /// <returns>Id de ingreso</returns>
        public int CrearHabitacion(HAB_Habitaciones habitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_Habitaciones.AddObject(habitacion);
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
        /// Método que obtiene un Habitación
        /// </summary>
        /// <param name="idHabitacion">Id del Habitación</param>
        /// <returns>Habitación</returns>
        public HAB_Habitaciones ObtenerHabitacion(int idHabitacion)
        {
            var retorno = new HAB_Habitaciones();
            try
            {
                retorno = _sisResEntities.HAB_Habitaciones.Single(tc => tc.IdHabitacion == idHabitacion);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todas las Habitaciones
        /// </summary>
        /// <returns>Lista de Habitaciones</returns>
        public List<HAB_Habitaciones> ObtenerHabitaciones()
        {
            var listaRetorno = new List<HAB_Habitaciones>();
            try
            {
                listaRetorno = _sisResEntities.HAB_Habitaciones.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza una Habitación
        /// </summary>
        /// <param name="habitacion">Datos de la Habitación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarHabitacion(HAB_Habitaciones habitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_Habitaciones.Attach(habitacion);
                _sisResEntities.ObjectStateManager.ChangeObjectState(habitacion, EntityState.Modified);
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
        /// Método que elimina una Habitación
        /// </summary>
        /// <param name="idHabitacion">Id de la Habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarHabitacion(int idHabitacion)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.HAB_Habitaciones", "IdHabitacion", idHabitacion), out objetoEliminar);
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
