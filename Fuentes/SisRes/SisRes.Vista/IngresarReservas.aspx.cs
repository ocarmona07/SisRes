using System.Linq;

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
            tbFechaReserva.Attributes.Add("readonly", "readonly");
            calFechaReserva.StartDate = DateTime.Today;
            tbHabitacionPrecio.Text = "$ " + tipoHabitacion[0].Precio;
            tbDescuento.Text = "0%";
            tbPrecioTotal.Text = "$ " + tipoHabitacion[0].Precio;

            if (string.IsNullOrEmpty(Request.QueryString["idReserva"])) return;

            hdnIdReserva.Value = Request.QueryString["idReserva"];
            LimpiarControles(null, null);

            var reserva = new ReservaHabitacionBo().ObtenerReservaHabitacion(int.Parse(hdnIdReserva.Value));
            var cliente = new ClientesBo().ObtenerCliente(reserva.RUTCliente);
            var habitacion = new HabitacionesBo().ObtenerHabitacion(reserva.IdHabitacion);
            habitacion.Disponible = true;
            new HabitacionesBo().ActualizarHabitacion(habitacion);
            var detalles = new DetalleReservasBo().ObtenerDetallesReservas();

            tbRutCliente.Text = reserva.RUTCliente + "";
            tbDvCliente.Text = cliente.DV;
            tbNombres.Text = cliente.Nombres;
            tbApPaterno.Text = cliente.ApPaterno;
            tbApMaterno.Text = cliente.ApMaterno;
            tbFono.Text = cliente.Fono + "";
            tbDireccion.Text = cliente.Direccion;
            tbEmail.Text = cliente.Email;
            tbObservacion.Text = reserva.Observacion;
            tbDescuento.Text = reserva.Descuento + "%";
            tbFechaReserva.Text = reserva.HoraFechaRes.ToShortDateString();
            chkEstadoCliente.Checked = cliente.Estado;

            ddlHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(tipoHabitacion[0].IdTipoHabitacion);
            ddlHabitacion.DataTextField = "Numero";
            ddlHabitacion.DataValueField = "IdHabitacion";
            ddlHabitacion.DataBind();

            ddlTipoCliente.SelectedValue = cliente.IdTipoCliente + "";
            ddlTipoHabitacion.SelectedValue = habitacion.IdTipoHabitacion + "";
            ddlHabitacion.SelectedValue = habitacion.IdHabitacion + "";
            ddlDias.SelectedValue = reserva.DiasReserva + "";

            foreach (GridViewRow fila in gvServicios.Rows)
            {
                var chkSevicio = ((CheckBox)fila.FindControl("chkServicio"));
                if (!chkSevicio.Checked) continue;

                var idServicio = int.Parse(((HiddenField)fila.FindControl("hdnServicio")).Value);
                chkSevicio.Checked = detalles.Count(det => idServicio.Equals(det.IdServicio)) > 0;
            }

            CambioServicio(null, null);
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
                new ClientesBo().CrearCliente(cliente);
            else
                new ClientesBo().ActualizarCliente(cliente);

            var reserva = new RES_ReservaHabitacion
            {
                RUTUsuario = Convert.ToInt32(Session["RUTUsuario"]),
                RUTCliente = Convert.ToInt32(tbRutCliente.Text),
                IdHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue),
                Observacion = tbObservacion.Text,
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

            LimpiarControles(null, null);
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
            var habitacion = new HabitacionesBo().ObtenerHabitacion(reserva.IdHabitacion);
            habitacion.Disponible = false;
            new HabitacionesBo().ActualizarHabitacion(habitacion);

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
            var habitacion = new HabitacionesBo().ObtenerHabitacion(reserva.IdHabitacion);
            habitacion.Disponible = false;
            new HabitacionesBo().ActualizarHabitacion(habitacion);
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

        /// <summary>
        /// Método que resetea los controles del formulario
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void LimpiarControles(object sender, EventArgs e)
        {
            tbRutCliente.Text = string.Empty;
            tbDvCliente.Text = string.Empty;
            tbNombres.Text = string.Empty;
            tbApPaterno.Text = string.Empty;
            tbApMaterno.Text = string.Empty;
            tbFono.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbObservacion.Text = string.Empty;
            tbDescuento.Text = "0%";
            chkEstadoCliente.Checked = true;

            ddlTipoCliente.SelectedIndex = -1;
            ddlTipoHabitacion.SelectedIndex = -1;
            ddlHabitacion.SelectedIndex = -1;
            ddlDias.SelectedIndex = -1;

            tbFechaReserva.Text = DateTime.Today.ToShortDateString();
            calFechaReserva.StartDate = DateTime.Today;


            ddlHabitacion.DataSource = new HabitacionesBo().ListaHabitaciones(1);
            ddlHabitacion.DataTextField = "Numero";
            ddlHabitacion.DataValueField = "IdHabitacion";
            ddlHabitacion.DataBind(); 
            
            gvServicios.DataSource = new ServiciosBo().ObtenerServicios();
            gvServicios.DataBind();

            CambioServicio(null, null);
        }
    }
}