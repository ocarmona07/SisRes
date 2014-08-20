namespace SisRes.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using Negocio;

    /// <summary>
    /// Clase principal de entrada al sitio
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            divCopyright.Controls.Add(new LiteralControl(new GeneralBo().Copyright));
        }
    }
}