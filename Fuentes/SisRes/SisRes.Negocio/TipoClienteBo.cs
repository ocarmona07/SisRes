namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para Tipos de Clientes
    /// </summary>
    public class TipoClienteBo
    {
        /// <summary>
        /// Método que almacena un Tipo de Cliente
        /// </summary>
        /// <param name="tipoCliente">Datos del Tipo de Cliente</param>
        /// <returns>Id de ingreso</returns>
        public int CrearTipoCliente(GEN_TipoCliente tipoCliente)
        {
            return new TipoClienteDa().CrearTipoCliente(tipoCliente);
        }

        /// <summary>
        /// Método que obtiene un Tipo de Cliente
        /// </summary>
        /// <param name="idTipoCliente">Id del Tipo de Cliente</param>
        /// <returns>TipoCliente</returns>
        public GEN_TipoCliente ObtenerTipoCliente(int idTipoCliente)
        {
            return new TipoClienteDa().ObtenerTipoCliente(idTipoCliente);            
        }

        /// <summary>
        /// Método que obtiene todos los Tipos de Clientes
        /// </summary>
        /// <returns>Lista de Tipo de Clientes</returns>
        public List<GEN_TipoCliente> ObtenerTipoCliente()
        {
            return new TipoClienteDa().ObtenerTiposClientes();            
        }

        /// <summary>
        /// Método que actualiza un Tipo de Cliente
        /// </summary>
        /// <param name="tipoCliente">Datos del Tipo de Cliente</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarTipoCliente(GEN_TipoCliente tipoCliente)
        {
            return new TipoClienteDa().ActualizarTipoCliente(tipoCliente);            
        }

        /// <summary>
        /// Método que elimina un Tipo de Cliente
        /// </summary>
        /// <param name="idTipoCliente">Id del Tipo de Cliente</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarTipoCliente(int idTipoCliente)
        {
            return new TipoClienteDa().EliminarTipoCliente(idTipoCliente);            
        }
    }
}
