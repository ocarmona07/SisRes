namespace SisRes.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
    }
}
