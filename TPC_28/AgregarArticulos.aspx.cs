using Dominio;
using Negocio;
using System;
using System.Collections.Generic;



namespace TPC_28
{
    public partial class AgregarArticulos : System.Web.UI.Page
    {
        public string imagenUrl { get; set; }
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

                    chkEliminacion.Checked = false;
                    chkEliminacion.Visible = false; // Ocultar checkbox inicialmente


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
                        txtImagen.Text = articulo.Imagenes.Count > 0 ? articulo.Imagenes[0]?.ImageUrl : "";

                        ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                        chkEliminacion.Visible = true;

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

                if (string.IsNullOrEmpty(txtNombre.Text) ||
                  string.IsNullOrEmpty(txtDescripcion.Text) ||
                  string.IsNullOrEmpty(txtDescripcionLarga.Text) ||
                  string.IsNullOrEmpty(txtPrecio.Text) ||
                  string.IsNullOrEmpty(ddlMarca.SelectedValue) ||
                  string.IsNullOrEmpty(ddlCategoria.SelectedValue))
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    return;
                }

                Articulo articulo = new Articulo();
                DatosDeArticulos articuloNuevo = new DatosDeArticulos();

                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.DescripcionLarga = txtDescripcionLarga.Text;

                decimal precio;

                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    lblErrorPrecio.Text = "Por favor, ingresa un valor válido para el precio.";
                    return;
                }

                if (precio <= 0)
                {
                    lblErrorPrecio.Text = "El precio debe ser mayor que cero.";
                    return;
                }

                articulo.Precio = precio;
                articulo.Imagenes = new List<Imagen>();
                articulo.Imagenes.Add(new Imagen { ImageUrl = txtImagen.Text });

                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);


                if (Request.QueryString["ArtId"] != null)
                {
                    articulo.ArtId = int.Parse(txtId.Text);
                    articuloNuevo.modificarConSp(articulo);
                    lblModificarMas.Text = "¡Modificado exitosamente!";
                    lblModificarMas.Visible = true;
                    btnAgregar.Visible = false;
                    btnModificarMas.Visible = true;
                    chkEliminacion.Visible = false;
                    
                }
                else
                {
                    articuloNuevo.agregarConSp(articulo);
                    lblConfirmacion.Text = "¡Guardado exitosamente!";
                    lblConfirmacion.Visible = true;
                    btnAgregar.Visible = false;
                    btnAgregarMas.Visible = true;
                    
                }



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
                        lblConfirmaEliminacion.Text = "¡Eliminado exitosamente!";
                        lblConfirmaEliminacion.Visible = true;
                        btnAgregar.Visible = false;
                        btnEliminar.Visible = false;
                        btnListado.Visible = true;
                        chkEliminacion.Visible = false;
                        borrarTodo();

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
            imagenUrl = txtImagen.Text;
            imgArticulo.ImageUrl = imagenUrl;




        }

        protected void chkEliminacion_CheckedChanged(object sender, EventArgs e)
        {
            btnEliminar.Visible = chkEliminacion.Checked;

        }

        protected void btnAgregarMas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulos.aspx");
        }

        protected void btnModificarMas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoDeArticulos.aspx");
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoDeArticulos.aspx");

        }

        void borrarTodo()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtDescripcionLarga.Text = "";
            txtPrecio.Text = "";
            txtImagen.Text = "";
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
        }

    }
}