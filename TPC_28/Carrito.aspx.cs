using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_28
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carro carro = Session["Cart"] as Carro;
                if (carro != null)
                {
                    repRepetidorCarrito.DataSource = carro.ListaArticulos;
                    repRepetidorCarrito.DataBind();
                }
            }
        }

        protected void irInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void verMas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArtDetalles.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnPeligro_Click(object sender, EventArgs e)
        {

        }
    }
}