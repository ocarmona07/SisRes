using System.Data;
using SisRes.Negocio;

namespace SisRes.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Clase de acceso al menu principal según perfil
    /// </summary>
    public partial class Reservas : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                ((HtmlGenericControl)Master.FindControl("liReservas")).Attributes.Add("class", "active");
            }

            if (IsPostBack) return;

            ddlTipoCliente.DataSource = new TipoClienteBo().ObtenerTiposClientes();
            ddlTipoCliente.DataTextField = "TipoCliente";
            ddlTipoCliente.DataValueField = "IdTipoCliente";
            ddlTipoCliente.DataBind();

            ddlTipoHabitacion.DataSource = new TipoHabitacionBo().ObtenerTiposHabitaciones();
            ddlTipoHabitacion.DataTextField = "TipoHabitacion";
            ddlTipoHabitacion.DataValueField = "IdTipoHabitacion";
            ddlTipoHabitacion.DataBind();

            ddlNumeroHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(1);
            ddlNumeroHabitacion.DataBind();

            ddlServicios.DataSource = new ServiciosBo().ObtenerServicios();
            ddlServicios.DataTextField = "Servicio";
            ddlServicios.DataValueField = "IdServicio";
            ddlServicios.DataBind();

            tbServicioPrecio.Text = decimal.Round(new ServiciosBo().ObtenerServicio(1).Precio, 0) + "";
        }

        /// <summary>
        /// Método que se llama al seleccionar un tipo de habitación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CambioNumeroHabitacion(object sender, EventArgs e)
        {
            ddlNumeroHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(ddlTipoHabitacion.SelectedIndex + 1);
            ddlNumeroHabitacion.DataBind();
        }

        protected void CambioServicios(object sender, EventArgs e)
        {
            tbServicioPrecio.Text = decimal.Round(new ServiciosBo().ObtenerServicio(int.Parse(ddlServicios.SelectedValue)).Precio, 0) + "";
        }

        protected void AgregarServicio(object sender, EventArgs e)
        {
            var servicio = new DataTable();
            servicio.Columns.Add("Servicio");
            servicio.Columns.Add("Precio");

            servicio.Rows.Add(ddlServicios.SelectedItem.Text, tbServicioPrecio.Text);

            gvServicios.DataSource = servicio;
            gvServicios.DataBind();
        }
    }
}