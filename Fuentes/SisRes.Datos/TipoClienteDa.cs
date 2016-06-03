namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para tipos de clientes
    /// </summary>
    public class TipoClienteDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public TipoClienteDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena un tipo de cliente
        /// </summary>
        /// <param name="tipoCliente">Datos del tipo de cliente</param>
        /// <returns>Id de ingreso</returns>
        public int CrearTipoCliente(GEN_TipoCliente tipoCliente)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_TipoCliente.AddObject(tipoCliente);
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
        /// Método que obtiene un tipo de cliente
        /// </summary>
        /// <param name="idTipoCliente">Id del tipo de cliente</param>
        /// <returns>Tipo de Cliente</returns>
        public GEN_TipoCliente ObtenerTipoCliente(int idTipoCliente)
        {
            var retorno = new GEN_TipoCliente();
            try
            {
                retorno = _sisResEntities.GEN_TipoCliente.Single(tc => tc.IdTipoCliente == idTipoCliente);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los tipos de clientes
        /// </summary>
        /// <returns>Lista de tipos de clientes</returns>
        public List<GEN_TipoCliente> ObtenerTiposClientes()
        {
            var listaRetorno = new List<GEN_TipoCliente>();
            try
            {
                listaRetorno = _sisResEntities.GEN_TipoCliente.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un tipo de cliente
        /// </summary>
        /// <param name="tipoCliente">Datos del tipo de cliente</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarTipoCliente(GEN_TipoCliente tipoCliente)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_TipoCliente.Attach(tipoCliente);
                _sisResEntities.ObjectStateManager.ChangeObjectState(tipoCliente, EntityState.Modified);
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
        /// Método que elimina un tipo de cliente
        /// </summary>
        /// <param name="idTipoCliente">Id del tipo de cliente</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarTipoCliente(int idTipoCliente)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.GEN_TipoCliente", "IdTipoCliente", idTipoCliente), out objetoEliminar);
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
