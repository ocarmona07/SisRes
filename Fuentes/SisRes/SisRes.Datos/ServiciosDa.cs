namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para servicios
    /// </summary>
    public class ServiciosDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public ServiciosDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena un servicio
        /// </summary>
        /// <param name="servicio">Datos del servicio</param>
        /// <returns>Id de ingreso</returns>
        public int CrearServicio(SER_Servicios servicio)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.SER_Servicios.AddObject(servicio);
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
        /// Método que obtiene un servicio
        /// </summary>
        /// <param name="idServicio">Id del servicio</param>
        /// <returns>Servicio</returns>
        public SER_Servicios ObtenerServicio(int idServicio)
        {
            var retorno = new SER_Servicios();
            try
            {
                retorno = _sisResEntities.SER_Servicios.Single(tc => tc.IdServicio == idServicio);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los servicios
        /// </summary>
        /// <returns>Lista de servicios</returns>
        public List<SER_Servicios> ObtenerServicios()
        {
            var listaRetorno = new List<SER_Servicios>();
            try
            {
                listaRetorno = _sisResEntities.SER_Servicios.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un servicio
        /// </summary>
        /// <param name="servicio">Datos del servicio</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarServicio(SER_Servicios servicio)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.SER_Servicios.Attach(servicio);
                _sisResEntities.ObjectStateManager.ChangeObjectState(servicio, EntityState.Modified);
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
        /// Método que elimina un servicio
        /// </summary>
        /// <param name="idServicio">Id del servicio</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarServicio(int idServicio)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.SER_Servicios", "IdServicio", idServicio), out objetoEliminar);
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
