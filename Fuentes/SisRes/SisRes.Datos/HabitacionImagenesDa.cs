namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Entidades;

    /// <summary>
    /// Clase de datos para imágenes de la habitación
    /// </summary>
    public class HabitacionImagenesDa
    {
        /// <summary>
        /// Entidades de SisRes
        /// </summary>
        private readonly SisResEntities _sisResEntities;

        /// <summary>
        /// Método que inicializa las entidades
        /// </summary>
        public HabitacionImagenesDa()
        {
            if (_sisResEntities == null)
                _sisResEntities = new SisResEntities();
        }

        /// <summary>
        /// Método que almacena una imagen de la habitación
        /// </summary>
        /// <param name="imagen">Datos de la imagen</param>
        /// <returns>Id de ingreso</returns>
        public int CrearImagenHabitacion(HAB_HabitacionImagenes imagen)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_HabitacionImagenes.AddObject(imagen);
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
        /// Método que obtiene una imagen de la habitación
        /// </summary>
        /// <param name="idHabitacion">Id de la habitación</param>
        /// <returns>Imagen de la Habitación</returns>
        public HAB_HabitacionImagenes ObtenerImagenHabitacion(int idHabitacion)
        {
            var retorno = new HAB_HabitacionImagenes();
            try
            {
                retorno = _sisResEntities.HAB_HabitacionImagenes.Single(tc => tc.IdHabitacion == idHabitacion);
                _sisResEntities.Dispose();
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Método que obtiene todas las imágenes de una habitación
        /// </summary>
        /// <returns>Lista de imágenes</returns>
        public List<HAB_HabitacionImagenes> ObtenerHabitacionImagenes()
        {
            var listaRetorno = new List<HAB_HabitacionImagenes>();
            try
            {
                listaRetorno = _sisResEntities.HAB_HabitacionImagenes.ToList();
                _sisResEntities.Dispose();
                return listaRetorno;
            }
            catch (Exception)
            {
                return listaRetorno;
            }
        }

        /// <summary>
        /// Método que actualiza una imagen de la habitación
        /// </summary>
        /// <param name="idImagen">Datos de la imagen</param>
        /// <returns>Id de actualización</returns>
        public int ActualizarImagenHabitacion(HAB_HabitacionImagenes idImagen)
        {
            var idRetorno = 0;
            try
            {
                _sisResEntities.HAB_HabitacionImagenes.Attach(idImagen);
                _sisResEntities.ObjectStateManager.ChangeObjectState(idImagen, EntityState.Modified);
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
        /// Método que elimina una imagen de la habitación
        /// </summary>
        /// <param name="idHabitacion">Id de la habitación</param>
        /// <returns>Id de confirmación</returns>
        public int EliminarImagenHabitacion(int idHabitacion)
        {
            var idRetorno = 0;
            try
            {
                object objetoEliminar;
                _sisResEntities.TryGetObjectByKey(new EntityKey("SisResEntities.HAB_HabitacionImagenes", "IdHabitacion", idHabitacion), out objetoEliminar);
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
