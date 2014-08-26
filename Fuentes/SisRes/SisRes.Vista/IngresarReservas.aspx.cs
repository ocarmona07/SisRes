namespace SisRes.Vista
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Negocio;
    using Entidades;

    /// <summary>
    /// Clase de acceso al menu principal según perfil
    /// </summary>
    public partial class IngresarReservas : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ddlTipoCliente.DataSource = new TipoClienteBo().ObtenerTiposClientes();
            ddlTipoCliente.DataTextField = "TipoCliente";
            ddlTipoCliente.DataValueField = "IdTipoCliente";
            ddlTipoCliente.DataBind();

            var tipoHabitacion = new TipoHabitacionBo().ObtenerTiposHabitaciones();
            ddlTipoHabitacion.DataSource = tipoHabitacion;
            ddlTipoHabitacion.DataTextField = "TipoHabitacion";
            ddlTipoHabitacion.DataValueField = "IdTipoHabitacion";
            ddlTipoHabitacion.DataBind();

            ddlHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(tipoHabitacion[0].IdTipoHabitacion);
            ddlHabitacion.DataTextField = "Numero";
            ddlHabitacion.DataValueField = "IdHabitacion";
            ddlHabitacion.DataBind();

            gvServicios.DataSource = new ServiciosBo().ObtenerServicios();
            gvServicios.DataBind();

            for (var i = 1; i < 100; i++) ddlDias.Items.Add(i + "");

            tbFechaReserva.Text = DateTime.Today.ToShortDateString();
            calFechaReserva.StartDate = DateTime.Today;
            tbHabitacionPrecio.Text = "$ " + tipoHabitacion[0].Precio;
            tbDescuento.Text = "0%";
            tbPrecioTotal.Text = "$ " + tipoHabitacion[0].Precio;
        }

        /// <summary>
        /// Método que se llama al seleccionar un tipo de habitación
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void CambioTipoHabitacion(object sender, EventArgs e)
        {
            var tipoHabitacion = int.Parse(ddlTipoHabitacion.SelectedValue);
            ddlHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(tipoHabitacion);
            ddlHabitacion.DataTextField = "Numero";
            ddlHabitacion.DataValueField = "IdHabitacion";
            ddlHabitacion.DataBind();

            tbHabitacionPrecio.Text = "$ " +
                new TipoHabitacionBo().ObtenerTipoHabitacion(tipoHabitacion).Precio;
            CambioServicio(null, null);
        }

        /// <summary>
        /// Método que ingresa la reserva al sistema
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void IngresarReserva(object sender, EventArgs e)
        {
            if (!new GeneralBo().ValidarRut(tbRutCliente.Text.Trim() + tbDvCliente.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('El RUT del cliente no es válido!');</script>", false);
                return;
            }

            var cliente = new GEN_Clientes
            {
                RUT = int.Parse(tbRutCliente.Text.Trim()),
                DV = tbDvCliente.Text,
                Nombres = tbNombres.Text.Trim(),
                ApPaterno = tbApPaterno.Text.Trim(),
                ApMaterno = tbApMaterno.Text.Trim(),
                Direccion = tbDireccion.Text.Trim(),
                Fono = int.Parse(tbFono.Text.Trim()),
                Email = tbEmail.Text.Trim(),
                IdTipoCliente = int.Parse(ddlTipoCliente.SelectedValue),
                Estado = chkEstadoCliente.Checked
            };
            if (new ClientesBo().ObtenerCliente(int.Parse(tbRutCliente.Text.Trim())).RUT <= 0)
            {
                new ClientesBo().CrearCliente(cliente);
            }
            else
            {
                new ClientesBo().ActualizarCliente(cliente);
            }

            var reserva = new RES_ReservaHabitacion
            {
                RUTUsuario = Convert.ToInt32(Session["RUTUsuario"]),
                RUTCliente = Convert.ToInt32(tbRutCliente.Text),
                IdHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue),
                HoraFechaRes = Convert.ToDateTime(tbFechaReserva.Text),
                DiasReserva = Convert.ToInt32(ddlDias.SelectedValue),
                Descuento = new TipoClienteBo().ObtenerTipoCliente(int.Parse(ddlTipoCliente.SelectedValue)).Descuento
            };

            string mensaje;
            if (string.IsNullOrEmpty(hdnIdReserva.Value))
            {
                mensaje = IngresarReserva(reserva) ? "Reserva almacenada correctamente." : "Error al guardar la reserva!";
            }
            else
            {
                reserva.IdReserva = int.Parse(hdnIdReserva.Value);
                mensaje = ModificarReserva(reserva) ? "Reserva actualizada correctamente." : "Error al actualizar la reserva";
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", @"<script language='javascript' type='text/javascript'>alert('" + mensaje + "');</script>", false);
        }

        /// <summary>
        /// Método que busca a un cliente en el sistema
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del botón</param>
        protected void BuscarCliente(object sender, ImageClickEventArgs e)
        {
            divBuscarCliente.Visible = true;
        }

        /// <summary>
        /// Método que se llama al cambiar el tipo de cliente
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void MostrarDescuento(object sender, EventArgs e)
        {
            tbDescuento.Text = new TipoClienteBo().ObtenerTipoCliente(int.Parse(ddlTipoCliente.SelectedValue)).Descuento + "%";
            CambioServicio(null, null);
        }

        /// <summary>
        /// Método que almacena una reserva y los servicios asociados
        /// </summary>
        /// <param name="reserva">Datos de la reserva</param>
        /// <returns>Confirmación</returns>
        private bool IngresarReserva(RES_ReservaHabitacion reserva)
        {
            var idReserva = new ReservaHabitacionBo().CrearReservaHabitacion(reserva);

            foreach (GridViewRow fila in gvServicios.Rows)
            {
                if (((CheckBox)fila.FindControl("chkServicio")).Checked)
                {
                    var idServicio = int.Parse(((HiddenField)fila.FindControl("hdnServicio")).Value);
                    var detalle = new RES_DetalleReserva
                    {
                        IdReserva = idReserva,
                        IdServicio = idServicio,
                        Precio = new ServiciosBo().ObtenerServicio(idServicio).Precio
                    };
                    new DetalleReservasBo().CrearDetalleReserva(detalle);
                }
            }

            return idReserva > 0;
        }

        /// <summary>
        /// Método que modifica una reserva
        /// </summary>
        /// <param name="reserva">Datos de la reserva</param>
        /// <returns>Confirmación</returns>
        public bool ModificarReserva(RES_ReservaHabitacion reserva)
        {
            var idReserva = new ReservaHabitacionBo().ActualizarReservaHabitacion(reserva);
            new DetalleReservasBo().EliminarDetalleReserva(idReserva);

            foreach (GridViewRow fila in gvServicios.Rows)
            {
                if (((CheckBox)fila.FindControl("chkServicio")).Checked)
                {
                    var idServicio = int.Parse(((HiddenField)fila.FindControl("hdnServicio")).Value);
                    var detalle = new RES_DetalleReserva
                    {
                        IdReserva = idReserva,
                        IdServicio = idServicio,
                        Precio = new ServiciosBo().ObtenerServicio(idServicio).Precio
                    };
                    new DetalleReservasBo().ActualizarDetalleReserva(detalle);
                }
            }

            return idReserva > 0;
        }

        /// <summary>
        /// Método que se llama al cambiar la selección de un CheckBox de servicio
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void CambioServicio(object sender, EventArgs e)
        {
            var precioTotal = 0;
            foreach (GridViewRow fila in gvServicios.Rows)
            {
                if (((CheckBox)fila.FindControl("chkServicio")).Checked)
                {
                    var idServicio = int.Parse(((HiddenField)fila.FindControl("hdnServicio")).Value);
                    precioTotal += new ServiciosBo().ObtenerServicio(idServicio).Precio;
                }
            }

            precioTotal += new TipoHabitacionBo().ObtenerTipoHabitacion(int.Parse(ddlTipoHabitacion.SelectedValue)).Precio;
            var descuento = new TipoClienteBo().ObtenerTipoCliente(int.Parse(ddlTipoCliente.SelectedValue)).Descuento;
            precioTotal = precioTotal - ((descuento * precioTotal) / 100);
            tbPrecioTotal.Text = "$ " + (precioTotal * int.Parse(ddlDias.SelectedValue));
        }
    }
}