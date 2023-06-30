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
            DatosDeArticulos  conector = new DatosDeArticulos();

            Imagen imagenes = new Imagen();
            DatosDeImagen iConector = new DatosDeImagen();


            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                art = conector.ListarConId(id);
                lblId.Text = art.ArtId.ToString();
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
    }
}