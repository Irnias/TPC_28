﻿using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_28
{
    public partial class ListadoDeArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDeArticulos datos = new DatosDeArticulos();
            dgvListaArticulos.DataSource = datos.Listar();
            dgvListaArticulos.DataBind();
        }

        protected void btnAgregarArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulos.aspx");
        }

        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {

        }

        protected void dgvListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ArtId = dgvListaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarArticulos.aspx?ArtId=" + ArtId);
        }

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaArticulos.PageIndex = e.NewPageIndex;
            dgvListaArticulos.DataBind();

        }
    }
}