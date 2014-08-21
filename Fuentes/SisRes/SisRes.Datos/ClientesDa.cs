namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para clientes
    /// </summary>
    public class ClientesDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public ClientesDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena un cliente
        /// </summary>
        /// <param name="cliente">Datos del cliente</param>
        /// <returns>Id de ingreso</returns>
        public int CrearCliente(GEN_Clientes cliente)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_Clientes.AddObject(cliente);
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
        /// Método que obtiene un cliente
        /// </summary>
        /// <param name="rutCliente">RUT del cliente</param>
        /// <returns>Cliente</returns>
        public GEN_Clientes ObtenerCliente(int rutCliente)
        {
            var retorno = new GEN_Clientes();
            try
            {
                retorno = _sisResEntities.GEN_Clientes.Single(tc => tc.RUT == rutCliente);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public List<GEN_Clientes> ObtenerClientes()
        {
            var listaRetorno = new List<GEN_Clientes>();
            try
            {
                listaRetorno = _sisResEntities.GEN_Clientes.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un cliente
        /// </summary>
        /// <param name="cliente">Datos del cliente</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarCliente(GEN_Clientes cliente)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_Clientes.Attach(cliente);
                _sisResEntities.ObjectStateManager.ChangeObjectState(cliente, EntityState.Modified);
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
        /// Método que elimina un cliente
        /// </summary>
        /// <param name="rutCliente">RUT del cliente</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarCliente(int rutCliente)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.GEN_Clientes", "RUT", rutCliente), out objetoEliminar);
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
