namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para roles
    /// </summary>
    public class RolesDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public RolesDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena un rol
        /// </summary>
        /// <param name="rol">Datos del role</param>
        /// <returns>Id de ingreso</returns>
        public int CrearRol(GEN_Rol rol)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_Rol.AddObject(rol);
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
        /// Método que obtiene un rol
        /// </summary>
        /// <param name="idRol">Id del role</param>
        /// <returns>Role</returns>
        public GEN_Rol ObtenerRol(int idRol)
        {
            var retorno = new GEN_Rol();
            try
            {
                retorno = _sisResEntities.GEN_Rol.Single(tc => tc.IdRol == idRol);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todos los roles
        /// </summary>
        /// <returns>Lista de roles</returns>
        public List<GEN_Rol> ObtenerRoles()
        {
            var listaRetorno = new List<GEN_Rol>();
            try
            {
                listaRetorno = _sisResEntities.GEN_Rol.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza un rol
        /// </summary>
        /// <param name="rol">Datos del rol</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarRol(GEN_Rol rol)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.GEN_Rol.Attach(rol);
                _sisResEntities.ObjectStateManager.ChangeObjectState(rol, EntityState.Modified);
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
        /// Método que elimina un rol
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarRol(int idRol)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.GEN_Roles", "IdRol", idRol), out objetoEliminar);
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
