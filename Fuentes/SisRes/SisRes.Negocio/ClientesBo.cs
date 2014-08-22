namespace SisRes.Negocio
{
    using System.Collections.Generic;
    using Entidades;
    using Datos;

    /// <summary>
    /// Clase de negocio para clientes
    /// </summary>
    public class ClientesBo
    {
        /// <summary>
        /// Método que almacena un cliente
        /// </summary>
        /// <param name="cliente">Datos del cliente</param>
        /// <returns>Id de ingreso</returns>
        public int CrearCliente(GEN_Clientes cliente)
        {
            return new ClientesDa().CrearCliente(cliente);
        }

        /// <summary>
        /// Método que obtiene un cliente
        /// </summary>
        /// <param name="rutCliente">RUT del cliente</param>
        /// <returns>Cliente</returns>
        public GEN_Clientes ObtenerCliente(int rutCliente)
        {
            return new ClientesDa().ObtenerCliente(rutCliente);            
        }

        /// <summary>
        /// Método que obtiene todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public List<GEN_Clientes> ObtenerClientes()
        {
            return new ClientesDa().ObtenerClientes();            
        }

        /// <summary>
        /// Método que actualiza un cliente
        /// </summary>
        /// <param name="cliente">Datos del cliente</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarCliente(GEN_Clientes cliente)
        {
            return new ClientesDa().ActualizarCliente(cliente);            
        }

        /// <summary>
        /// Método que elimina un cliente
        /// </summary>
        /// <param name="rutCliente">RUT del cliente</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarCliente(int rutCliente)
        {
            return new ClientesDa().EliminarCliente(rutCliente);            
        }
    }
}
