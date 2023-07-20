using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPC_28
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDeArticulos conector = new DatosDeArticulos();
            ListadoDeArticulos = conector.obtenerArticulosConDetalles();
            List<ArticulosConDetalles> toShow = new List<ArticulosConDetalles>();
            CarroConArticulos carro = Session["Cart"] as CarroConArticulos;

            if (carro != null)
            {
                foreach (var item in ListadoDeArticulos)
                {
                    if (carro.tieneIdArticulo(item.ArtId))
                    {
                        item.Cantidad = carro.GetArticleQuantity(item.ArtId);
                        toShow.Add(item);
                    }
                }

                if (!IsPostBack)
                {
                    repRepetidorCarrito.DataSource = toShow;
                    repRepetidorCarrito.DataBind();
                }

                decimal total = 0;
                foreach (var item in toShow)
                {
                    total += item.Precio * item.Cantidad;
                }

                lblTotal.Text = total.ToString("0.00");

                CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
                if (currentCart != null)
                {
                    Master.UpdateCartItemCount(currentCart.GetTotalItems());
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar_Click = (Button)sender;
            int artId = int.Parse(btnAgregar_Click.CommandArgument);

            CarroConArticulos carro = Session["Cart"] as CarroConArticulos;
            if (carro == null)
            {
                carro = new CarroConArticulos();
                Session["Cart"] = carro;
            }
            ArtDentroDelCarrito current = new ArtDentroDelCarrito(artId);

            carro.agregarArticulo(current);
            Response.Redirect("Carrito.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar_Click = (Button)sender;
            int artId = int.Parse(btnEliminar_Click.CommandArgument);

            CarroConArticulos carro = Session["Cart"] as CarroConArticulos;
            if (carro == null)
            {
                carro = new CarroConArticulos();
                Session["Cart"] = carro;
            }
            ArtDentroDelCarrito current = new ArtDentroDelCarrito(artId);

            carro.eliminarArticulo(current);
            Response.Redirect("Carrito.aspx");

        }

        protected void btnPeligro_Click(object sender, EventArgs e)
        {
            Button btnPeligro_Click = (Button)sender;
            int artId = int.Parse(btnPeligro_Click.CommandArgument);

            CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
            if (currentCart != null)
            {

                ArtDentroDelCarrito current = new ArtDentroDelCarrito(artId);
                currentCart.removerArticulo(current);

                Response.Redirect("Carrito.aspx");
            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResumenDeCompra.aspx");
        }
    }
}