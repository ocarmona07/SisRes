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
    public class DetalleReservasDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public DetalleReservasDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena el Detalle de una Reserva
        /// </summary>
        /// <param name="detalleReserva">Datos del Detalle</param>
        /// <returns>Id de ingreso</returns>
        public int CrearDetalleReserva(RES_DetalleReserva detalleReserva)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.RES_DetalleReserva.AddObject(detalleReserva);
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
        /// Método que obtiene el Detalle de una Reserva
        /// </summary>
        /// <param name="idDetalle">Id de la reserva</param>
        /// <returns>Detalle de Reserva</returns>
        public RES_DetalleReserva ObtenerDetalleReserva(int idDetalle)
        {
            var retorno = new RES_DetalleReserva();
            try
            {
                retorno = _sisResEntities.RES_DetalleReserva.Single(tc => tc.IdReserva == idDetalle);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los Detalles de Reservas
        /// </summary>
        /// <returns>Lista de Detalles</returns>
        public List<RES_DetalleReserva> ObtenerDetallesReservas()
        {
            var listaRetorno = new List<RES_DetalleReserva>();
            try
            {
                listaRetorno = _sisResEntities.RES_DetalleReserva.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un Detalle de Reserva
        /// </summary>
        /// <param name="detalleReserva">Datos del Detalle</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarDetalleReserva(RES_DetalleReserva detalleReserva)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.RES_DetalleReserva.Attach(detalleReserva);
                _sisResEntities.ObjectStateManager.ChangeObjectState(detalleReserva, EntityState.Modified);
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
        /// Método que elimina el Detalle de una Reserva
        /// </summary>
        /// <param name="idDetalle">Id del Detalle</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarDetalleReserva(int idDetalle)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.RES_DetalleReserva", "IdReserva", idDetalle), out objetoEliminar);
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
