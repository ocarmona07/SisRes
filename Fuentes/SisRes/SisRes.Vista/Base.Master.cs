namespace SisRes.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using SisRes.Negocio;

    /// <summary>
    /// Clase base para la funcionalidad del mantenedor
    /// </summary>
    public partial class Base : MasterPage
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            divCopyright.Controls.Add(new LiteralControl(new GeneralBo().Copyright));

            if (IsPostBack) return;

            if (string.IsNullOrEmpty(Session["RUTUsuario"].ToString()))
                Response.Redirect("Index.aspx");
        }
    }
}