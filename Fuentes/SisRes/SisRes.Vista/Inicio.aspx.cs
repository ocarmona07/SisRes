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
    public partial class Inicio : Page
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
                ((HtmlGenericControl)Master.FindControl("liInicio")).Attributes.Add("class", "active");
            }
        }
    }
}