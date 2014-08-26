namespace SisRes.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using Entidades;
    using Negocio;

    /// <summary>
    /// Clase encargada de mantener los módulos
    /// </summary>
    public partial class ListaReservas : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            gvReservas.DataSource = new ReservaHabitacionBo().ObtenerReservasHabitaciones();
            gvReservas.DataBind();
        }

        /// <summary>
        /// Método que se llama al seleccionar un item de la grilla de reservas
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos de la grilla</param>
        protected void ReservasRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    //CrearEvento(null, null);
                    //var editarEvento = new EventosBo().ObtenerEvento(int.Parse(e.CommandArgument.ToString()));
                    //hdnIdEvento.Value = e.CommandArgument.ToString();
                    //ddlEventoRequerimiento.SelectedValue = editarEvento.EVE_REQ_ID.ToString(CultureInfo.InvariantCulture);
                    //ddlEventoEstado.SelectedValue = editarEvento.EVE_EST_ID.ToString(CultureInfo.InvariantCulture);
                    //ibEventoAdjunto.CommandArgument = editarEvento.EVE_ADJUNTO;
                    //tbEventoNombreResponsable.Text = editarEvento.EVE_RESPONSABLE;
                    //tbEventoDescripcion.Text = editarEvento.EVE_DESCRIPCION;
                    //tbEventoFecha.Text = editarEvento.EVE_FECHA.ToShortDateString();
                    //btnEventoCrear.Text = "Modificar";
                    break;

                case "Eliminar":
                    var mensaje = new ReservaHabitacionBo().EliminarReservaHabitacion(int.Parse(e.CommandArgument.ToString())) > 0
                        ? "Reserva eliminada correctamente"
                        : "Error al eliminar la reserva";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "MensajeEliminar", @"<script language='javascript' type='text/javascript'>alert('" + mensaje + "');</script>", false);
                    gvReservas.DataSource = new ReservaHabitacionBo().ObtenerReservasHabitaciones();
                    gvReservas.DataBind();
                    break;
            }
        }
    }
}