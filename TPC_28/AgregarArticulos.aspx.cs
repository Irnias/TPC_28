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
                marcaPopup.Visible = false;
                categoriaPopup.Visible = false;
                if (!IsPostBack)
                {
                    Recargar_Marca();
                    Recargar_Categoria();

                    chkEliminacion.Checked =false;

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
                        txtImagen.Text = articulo.Imagenes.ImageUrl;

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

        protected void Recargar_Marca()
        {
            DatosMarca marca = new DatosMarca();
            List<Marca> lista = marca.Listar();

            ddlMarca.DataSource = lista;
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataBind();
        }

        protected void Recargar_Categoria()
        {
            DatosCategoria categoria = new DatosCategoria();
            List<Categoria> listaC = categoria.Listar();
            ddlCategoria.DataSource = listaC;
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = new Articulo();
                DatosDeArticulos articuloNuevo = new DatosDeArticulos();

                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.DescripcionLarga = txtDescripcionLarga.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Imagenes = new Imagen();
                articulo.Imagenes.ImageUrl = txtImagen.Text;

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

        protected void btnNuevaMarca(object sender, EventArgs e)
        {
            marcaPopup.Visible = true;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            DatosMarca marca = new DatosMarca();
            marca.NuevaMarca(txtNombreMarca.Text);
            txtNombreMarca.Text = "";
            Recargar_Marca();
            marcaPopup.Visible = false;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            marcaPopup.Visible = false;
        }

        protected void Agregar_Categoria(object sender, EventArgs e)
        {
            categoriaPopup.Visible = true;
        }

        protected void BtnCategoriaGuardar_Click(object sender, EventArgs e)
        {
            DatosCategoria categoria = new DatosCategoria();
            categoria.NuevaCategoria(txtNombreCategoria.Text);
            txtNombreCategoria.Text = "";
            Recargar_Categoria();
            categoriaPopup.Visible = false;
        }

        protected void BtnCategoriaCancelar_Click(object sender, EventArgs e)
        {
            categoriaPopup.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string artId = Request.QueryString["ArtId"];
                int idArticulo;

                if (artId != null && chkEliminacion.Checked)
                {
                    if (int.TryParse(artId, out idArticulo)) 
                    {
                        DatosDeArticulos articulo = new DatosDeArticulos();

                        Articulo articuloEliminar = new Articulo();
                        articuloEliminar.ArtId = idArticulo;

                        articulo.eliminarConSp(articuloEliminar);

                    }
                }
                Response.Redirect("ListadoDeArticulos.aspx", false);


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
         //  urlImagen = txtImagen.Text;
            
           

        }
    }
}