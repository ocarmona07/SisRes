namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para Tipo de Habitaciones
    /// </summary>
    public class TipoHabitacionDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public TipoHabitacionDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena un tipo de habitación
        /// </summary>
        /// <param name="tipoHabitacion">Datos del tipo de habitación</param>
        /// <returns>Id de ingreso</returns>
        public int CrearTipoHabitacion(HAB_TipoHabitacion tipoHabitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_TipoHabitacion.AddObject(tipoHabitacion);
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
        /// Método que obtiene un tipo de habitación
        /// </summary>
        /// <param name="idTipoHabitacion">Id del tipo de habitación</param>
        /// <returns>Tipo de Habitación</returns>
        public HAB_TipoHabitacion ObtenerTipoHabitacion(int idTipoHabitacion)
        {
            var retorno = new HAB_TipoHabitacion();
            try
            {
                retorno = _sisResEntities.HAB_TipoHabitacion.Single(tc => tc.IdTipoHabitacion == idTipoHabitacion);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los tipos de habitación
        /// </summary>
        /// <returns>Lista de tipos de habitación</returns>
        public List<HAB_TipoHabitacion> ObtenerTiposHabitaciones()
        {
            var listaRetorno = new List<HAB_TipoHabitacion>();
            try
            {
                listaRetorno = _sisResEntities.HAB_TipoHabitacion.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un tipo de habitación
        /// </summary>
        /// <param name="tipoHabitacion">Datos del tipo de habitación</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarTipoHabitacion(HAB_TipoHabitacion tipoHabitacion)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_TipoHabitacion.Attach(tipoHabitacion);
                _sisResEntities.ObjectStateManager.ChangeObjectState(tipoHabitacion, EntityState.Modified);
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
        /// Método que elimina un tipo de habitación
        /// </summary>
        /// <param name="idTipoHabitacion">Id del tipo de habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarTipoHabitacion(int idTipoHabitacion)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.HAB_TipoHabitacion", "IdTipoHabitacion", idTipoHabitacion), out objetoEliminar);
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
