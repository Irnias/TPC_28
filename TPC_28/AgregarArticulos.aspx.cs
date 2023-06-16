using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_28
{
    public partial class AgregarArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DatosMarca marca = new DatosMarca();
                    List<Marca> lista = marca.Listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    DatosCategoria categoria = new DatosCategoria();
                    List<Categoria> listaC = categoria.Listar();
                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = new Articulo();
                AccesoDatos articuloNuevo = new AccesoDatos();

                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.DescripcionLarga = txtDescripcionLarga.Text;

                articulo.Imagenes = new Imagen();
                articulo.Imagenes.ImageUrl = txtImagen.Text;

                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                articuloNuevo.agregar(articulo);
                Response.Redirect("AgregarArticulos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}