using System;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_28
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDeArticulos art = new DatosDeArticulos();
            repRepetidor.DataSource = art.Listar();


            if (!IsPostBack)
            {
                repRepetidor.DataSource = art.Listar();

                repRepetidor.DataBind();


            }
        }

        protected void irCarrito_Click(object sender, EventArgs e)
        {
            Button irCarrito = (Button)sender;
            string id = irCarrito.CommandArgument;

            Response.Redirect("carrito.aspx?id=" + id);
        }

        protected void verMas_Click(object sender, EventArgs e)
        {
            Button verMas = (Button)sender;
            string id = verMas.CommandArgument;

            Response.Redirect("artDetalles.aspx?id=" + id);
        }
    }
}