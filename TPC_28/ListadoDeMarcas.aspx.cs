using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_28
{
    public partial class ListadoDeMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            marcaPopup.Visible = false;
            Recargar_Marca();
        }

        protected void dgvListaMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(dgvListaMarcas.SelectedDataKey.Value);
            DatosMarca datos = new DatosMarca();
            datos.BorradoLogicoPorId(Id);
        }

        protected void dgvListaMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaMarcas.PageIndex = e.NewPageIndex;
            dgvListaMarcas.DataBind();

        }

        protected void Recargar_Marca()
        {
            DatosMarca datos = new DatosMarca();
            dgvListaMarcas.DataSource = datos.Listar();
            dgvListaMarcas.DataBind();
        }

        protected void Agregar_Marca(object sender, EventArgs e)
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

    }
}