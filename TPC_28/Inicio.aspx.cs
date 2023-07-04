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


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar_Click = (Button)sender;
            string id = btnAgregar_Click.CommandArgument;

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


        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Button btnEliminar_Click = (Button)sender;
            string id = btnEliminar_Click.CommandArgument;

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

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Button btnRestar_Click = (Button)sender;
            int artId = int.Parse(btnRestar_Click.CommandArgument);

            CarroConArticulos carro = Session["Cart"] as CarroConArticulos;
            if (carro == null)
            {
                carro = new CarroConArticulos();
                Session["Cart"] = carro;
            }
            Carro current = new Carro(artId);

            carro.eliminarArticulo(current);
            Response.Redirect("Inicio.aspx");
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Button btnSumar_Click = (Button)sender;
            int artId = int.Parse(btnSumar_Click.CommandArgument);

            CarroConArticulos cart = Session["Cart"] as CarroConArticulos;
            if (cart == null)
            {
                cart = new CarroConArticulos();
                Session["Cart"] = cart;
            }
            Carro current = new Carro(artId);

            cart.agregarArticulo(current);
            Response.Redirect("Inicio.aspx");
        }



        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ArticulosConDetalles articulo = e.Item.DataItem as ArticulosConDetalles;


                Button btnAgregado = e.Item.FindControl("btnAgregado") as Button;
                Button btnAgregar = e.Item.FindControl("btnAgregar") as Button;
                Button btnEliminar = e.Item.FindControl("btnEliminar") as Button;
                Button btnSumar = e.Item.FindControl("btnSumar") as Button;
                Button btnRestar = e.Item.FindControl("btnRestar") as Button;

                CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;

                if (currentCart != null && currentCart.tieneIdArticulo(articulo.ArtId))
                {
                    btnAgregado.Visible = true;
                    btnEliminar.Visible = true;
                    btnAgregar.Visible = false;
                    btnSumar.Visible = true;
                    btnRestar.Visible = true;
                }
                else
                {
                    btnAgregado.Visible = false;
                    btnEliminar.Visible = false;
                    btnAgregar.Visible = true;
                    btnSumar.Visible = false;
                    btnRestar.Visible = false;
                }


            }
        }

        protected void btnAgregado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

    }

}


