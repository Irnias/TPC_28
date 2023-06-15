using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_28
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDeArticulos art = new DatosDeArticulos();
            // dgvArticulos.DataSource = art.Listar();
            // dgvArticulos.DataBind();
            repRepetidor.DataSource = art.Listar();
            repRepetidor.DataBind();
        }

        protected void irCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void verMas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArtDetalles.aspx");
        }
    }
}