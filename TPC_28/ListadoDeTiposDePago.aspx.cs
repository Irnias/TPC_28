using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_28
{
    public partial class ListadoTiposDePago : System.Web.UI.Page
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
            ListaTiposDePagoPopup.Visible = false;
            Recargar_TipoPago();
        }
        protected void dgvListaTiposDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(dgvListaTiposDePago.SelectedDataKey.Value);
            DatosTipoPagos datos = new DatosTipoPagos();
            datos.BorradoLogicoPorId(Id);
        }

        protected void dgvListaTiposDePago_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaTiposDePago.PageIndex = e.NewPageIndex;
            dgvListaTiposDePago.DataBind();

        }

        protected void Recargar_TipoPago()
        {
            DatosTipoPagos datos = new DatosTipoPagos();
            dgvListaTiposDePago.DataSource = datos.Listar();
            dgvListaTiposDePago.DataBind();
        }

        protected void Agregar_TipoPago(object sender, EventArgs e)
        {
            ListaTiposDePagoPopup.Visible = true;
        }

        protected void BtnTipoPagoGuardar_Click(object sender, EventArgs e)
        {
            DatosTipoPagos datos = new DatosTipoPagos();
            datos.NuevoTipoDePago(txtNombreTipoDePago.Text);
            txtNombreTipoDePago.Text = "";
            Recargar_TipoPago();
            ListaTiposDePagoPopup.Visible = false;
        }

        protected void BtnTipoPagoCancelar_Click(object sender, EventArgs e)
        {
            ListaTiposDePagoPopup.Visible = false;
        }

    }
}