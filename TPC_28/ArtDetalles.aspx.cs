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
    public partial class ArtDetalles : System.Web.UI.Page
    {
        public List<Articulo> ListadoDeArticulos { get; set; }

        public List<Imagen> ListadoDeImagenes = new List<Imagen>();
        protected void Page_Load(object sender, EventArgs e)
        {

            Articulo art = new Articulo();
            DatosDeArticulos conector = new DatosDeArticulos();

            Imagen imagenes = new Imagen();
            DatosDeImagen iConector = new DatosDeImagen();

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                lblArtId.Text = id.ToString();
                btnEliminar.CommandArgument = id.ToString();
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                art = conector.ListarConId(id);

                //lblArtId.Text = art.ArtId.ToString();
                lblBrand.Text = art.Marca.Descripcion;
                lblName.Text = art.Nombre;
                lblCategory.Text = art.Categoria.Descripcion;
                lblDescription.Text = art.DescripcionLarga;
                lblPrice.Text = art.Precio.ToString();

                ListadoDeImagenes = iConector.FetchImageById(id);

                imageRepeater.DataSource = ListadoDeImagenes;
                imageRepeater.DataBind();          
            }            
        }

        protected void irInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            Button btnAgregar_Click = (Button)sender;
            if (btnAgregar_Click.CommandName == "AgregarCarrito")
            {
                int articleId;
                if (int.TryParse(Request.QueryString["id"], out articleId))
                {
                    CarroConArticulos carroArt = Session["Cart"] as CarroConArticulos;
                    if (carroArt == null)
                    {
                        carroArt = new CarroConArticulos();
                        Session["Cart"] = carroArt;
                    }

                    Carro agregarArt = new Carro(articleId);
                    carroArt.agregarArticulo(agregarArt);

                    Session["Cart"] = carroArt;
                    Master.UpdateCartItemCount(carroArt.GetTotalItems());

                    btnEliminar.Visible = true;
                }
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
                    btnEliminar.Visible = false;
                }
            }
        }

        protected void Inicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}