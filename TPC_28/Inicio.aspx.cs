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
    public partial class Inicio : System.Web.UI.Page
    {
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }

        public List<Articulo> ArtList = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDeArticulos conector = new DatosDeArticulos();
            ListadoDeArticulos = conector.obtenerArticulosConDetalles();
            ArtList = ListadoDeArticulos.Cast<Articulo>().ToList();


            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListadoDeArticulos;
                repRepetidor.DataBind();
            }

            CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
            if (currentCart != null)
            {
                Master.UpdateCartItemCount(currentCart.GetTotalItems());
            }
        }

        protected void verMas_Click(object sender, EventArgs e)
        {
            Button verMas = (Button)sender;
            string id = verMas.CommandArgument;

            Response.Redirect("artDetalles.aspx?id=" + id);
        }



        protected void irCarrito_Click(object sender, EventArgs e)
        {
            Button irCarrito = (Button)sender;
            string id = irCarrito.CommandArgument;

            CarroConArticulos carroArt = Session["Cart"] as CarroConArticulos;
            if (carroArt == null)
            {
                carroArt = new CarroConArticulos();
                Session["Cart"] = carroArt;
            }

            int articleId;
            if (int.TryParse(id, out articleId))
            {
                Carro agregarArt = new Carro(articleId);

                carroArt.agregarArticulo(agregarArt);
                Session["Cart"] = carroArt;
                Master.UpdateCartItemCount(carroArt.GetTotalItems());
                repRepetidor.DataSource = ListadoDeArticulos;
                repRepetidor.DataBind();
            }
        }


        protected void eliminarArticulo_Click(object sender, EventArgs e)
        {

            Button eliminarArticulo = (Button)sender;
            string id = eliminarArticulo.CommandArgument;

            CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
            if (currentCart != null)
            {
                int articleId;
                if (int.TryParse(id, out articleId))
                {
                    Carro current = new Carro(articleId);
                    currentCart.removerArticulo(current);
                    Session["Cart"] = currentCart;
                    Master.UpdateCartItemCount(currentCart.GetTotalItems());
                    repRepetidor.DataSource = ListadoDeArticulos;
                    repRepetidor.DataBind();
                }
            }

        }
    }

}


