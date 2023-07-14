using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_28
{
    public partial class ListadoDeCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Inicio.aspx", false);
            }
            else
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user.TipoUsuario != TipoUsuario.SuperAdmin)
                {
                    Response.Redirect("Inicio.aspx", false);
                }
            }
            categoriaPopup.Visible = false;
            Recargar_Categoria();
        }

        protected void dgvListaCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(dgvListaCategoria.SelectedDataKey.Value);
            DatosCategoria datos = new DatosCategoria();
            datos.BorradoLogicoPorId(Id);
        }

        protected void dgvListaCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaCategoria.PageIndex = e.NewPageIndex;
            dgvListaCategoria.DataBind();

        }

        protected void Recargar_Categoria()
        {
            DatosCategoria datos = new DatosCategoria();
            dgvListaCategoria.DataSource = datos.Listar();
            dgvListaCategoria.DataBind();
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

    }
}