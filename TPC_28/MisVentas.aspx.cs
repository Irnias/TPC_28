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
                CargarCompras();
            }
        }

        private void CargarCompras()
        {
            List<Compra> listaCompras = datosCompra.Listar();
             dgvListaVentas.DataSource = listaCompras;
             dgvListaVentas.DataBind();
        }

        protected void dgvListaVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvListaVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}