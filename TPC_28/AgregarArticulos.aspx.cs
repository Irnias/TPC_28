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
                txtId.Enabled = false;

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

                string ArtId = Request.QueryString["ArtId"] != null ? Request.QueryString["ArtId"].ToString() : "";
           

                if (ArtId != "" && !IsPostBack)
                {
                    int idArt;
                    if (int.TryParse(ArtId, out idArt))
                    {
                        DatosDeArticulos datos = new DatosDeArticulos();
                        Articulo articulo = datos.ListarConId(idArt);

                        txtId.Text = articulo.ArtId.ToString();
                        txtNombre.Text = articulo.Nombre;
                        txtDescripcion.Text = articulo.Descripcion;
                        txtDescripcionLarga.Text = articulo.DescripcionLarga;
                        txtPrecio.Text = articulo.Precio.ToString();

                        ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                    }
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
                DatosDeArticulos articuloNuevo = new DatosDeArticulos();

                articulo.ArtId = int.Parse(txtId.Text);

                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.DescripcionLarga = txtDescripcionLarga.Text;

                articulo.Imagenes = new Imagen();
                articulo.Imagenes.Id = int.Parse(txtImagen.Text);

                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["ArtId"] != null)
                {
                    articulo.ArtId = int.Parse(txtId.Text);
                    articuloNuevo.modificarConSp(articulo);
                }
                else
                {
                    articuloNuevo.agregarConSp(articulo);
                }

                Response.Redirect("AgregarArticulos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}