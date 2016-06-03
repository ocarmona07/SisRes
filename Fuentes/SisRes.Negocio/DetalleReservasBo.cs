namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Detalle de Reservas
    /// </summary>
    public class DetalleReservasBo
    {
        /// <summary>
        /// Método que almacena el Detalle de una Reserva
        /// </summary>
        /// <param name="detalleReserva">Datos del Detalle</param>
        /// <returns>Id de ingreso</returns>
        public int CrearDetalleReserva(RES_DetalleReserva detalleReserva)
        {
            return new DetalleReservasDa().CrearDetalleReserva(detalleReserva);
        }

        /// <summary>
        /// Método que obtiene el Detalle de una Reserva
        /// </summary>
        /// <param name="idDetalleReserva">Id del detalleReserva</param>
        /// <returns>Detalle de Reserva</returns>
        public RES_DetalleReserva ObtenerDetalleReserva(int idDetalleReserva)
        {
            return new DetalleReservasDa().ObtenerDetalleReserva(idDetalleReserva);            
        }

        /// <summary>
        /// Método que obtiene todos los Detalle de Reservas
        /// </summary>
        /// <returns>Lista de Detalles</returns>
        public List<RES_DetalleReserva> ObtenerDetallesReservas()
        {
            return new DetalleReservasDa().ObtenerDetallesReservas();            
        }

        /// <summary>
        /// Método que actualiza el Detalle de una Reserva
        /// </summary>
        /// <param name="detalleReserva">Datos del Detalle</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarDetalleReserva(RES_DetalleReserva detalleReserva)
        {
            return new DetalleReservasDa().ActualizarDetalleReserva(detalleReserva);            
        }

        /// <summary>
        /// Método que elimina el Detalle de una Reserva
        /// </summary>
        /// <param name="idDetalleReserva">Id del Detalle</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarDetalleReserva(int idDetalleReserva)
        {
            return new DetalleReservasDa().EliminarDetalleReserva(idDetalleReserva);            
        }
    }
}
