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
    public partial class MisVentas : System.Web.UI.Page
    {
        private DatosCompra datosCompra = new DatosCompra();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Compra> listaCompras = datosCompra.Listar();
              
                dgvListaVentas.DataSource = listaCompras;
                dgvListaVentas.DataBind();
            }
        }

        protected void dgvListaVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosCompra compras = new DatosCompra();
            List<Compra> listaCompras = datosCompra.Listar();
            int idCompra = Convert.ToInt32(dgvListaVentas.SelectedDataKey.Value);

            Estado estadoActual = (Estado)Enum.Parse(typeof(Estado), dgvListaVentas.SelectedDataKey.Values["Estado"].ToString());

            Estado nuevoEstado = Estado.Pendiente;
            if (estadoActual == Estado.Pendiente)
            {
                nuevoEstado = Estado.EnProceso;
                compras.ModificarEstado(idCompra, nuevoEstado);

            }
            else if (estadoActual == Estado.EnProceso)
            {
                nuevoEstado = Estado.Completado;
                compras.ModificarEstado(idCompra, nuevoEstado);
            }
            else if (estadoActual == Estado.Completado)
            {
                nuevoEstado = Estado.Eliminado;
                compras.ModificarEstado(idCompra, nuevoEstado);
            }

            dgvListaVentas.DataSource = listaCompras;
            dgvListaVentas.DataBind();

            Response.Redirect("MisVentas.aspx");
        }

        protected void dgvListaVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void ModificarEstado_Click(object sender, EventArgs e)
        {

        }

    }
}