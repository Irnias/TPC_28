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
    public partial class ResumenDeCompra : System.Web.UI.Page
    {
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    DatosDeArticulos conector = new DatosDeArticulos();
                    ListadoDeArticulos = conector.obtenerArticulosConDetalles();
                    List<ArticulosConDetalles> toShow = new List<ArticulosConDetalles>();
                    CarroConArticulos carro = Session["Cart"] as CarroConArticulos;


                    RecargarFormaDePago();
                    RecargarFormaDeEnvio();

               
                    if (carro != null)
                    {

                        foreach (var item in ListadoDeArticulos)
                        {
                            if (carro.tieneIdArticulo(item.ArtId))
                            {
                                item.Cantidad = carro.GetArticleQuantity(item.ArtId);
                                toShow.Add(item);
                            }
                        }


                        repRepetidorCarrito.DataSource = toShow;
                        repRepetidorCarrito.DataBind();

                      /*  TipoEnvios envios = new TipoEnvios();
                        ddlEnvio.SelectedValue = envios.Id.ToString();
                      */


                       // ddlEnvio.SelectedIndexChanged += ddlEnvio_SelectedIndexChanged;


                        decimal total = 0;
                        foreach (var item in toShow)
                        {
                            total += item.Precio * item.Cantidad;
                        }

                        lblTotal.Text = total.ToString("0.00");

                        CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
                        if (currentCart != null)
                        {
                            Master.UpdateCartItemCount(currentCart.GetTotalItems());
                        }
                    }
                }
                else
                {
                    Session.Add("error", "Tenes que iniciar sesión/registrarte para poder comprar");
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void ddlEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEnvio.SelectedValue == "1")
            {
                lblEnvio.Visible = true;

                txtCiudad.Visible = false;
                txtCodigoPostal.Visible = false;
                txtDepartamento.Visible = false;
                txtDomicilio.Visible = false;
                txtNumero.Visible = false;
                txtPais.Visible = false;
                txtPiso.Visible = false;

            }
            else if (ddlEnvio.SelectedValue == "2")
            {
                lblEnvio.Visible = false;

                txtCiudad.Visible = true;
                txtCodigoPostal.Visible = true;
                txtDepartamento.Visible = true;
                txtDomicilio.Visible = true;
                txtNumero.Visible = true;
                txtPais.Visible = true;
                txtPiso.Visible = true;
            }
        }

        protected void RecargarFormaDePago()
        {
            DatosTipoPagos tipos = new DatosTipoPagos();
            List<TipoPagos> listar = tipos.Listar();

            ddlFormaDePago.DataSource = listar;
            ddlFormaDePago.DataValueField = "Id";
            ddlFormaDePago.DataTextField = "Descripcion";
            ddlFormaDePago.DataBind();
        }

        protected void RecargarFormaDeEnvio()
        {
            DatosTipoEnvios envio = new DatosTipoEnvios();
            List<TipoEnvios> lista = envio.Listar();

            ddlEnvio.DataSource = lista;
            ddlEnvio.DataValueField = "Id";
            ddlEnvio.DataTextField = "Descripcion";
            ddlEnvio.DataBind();
        }

        protected void guardarDireccion_Click(object sender, EventArgs e)
        {
            DireccionEnvio direccion = new DireccionEnvio();

            direccion.Calle = txtDomicilio.Text;
            direccion.Numero = int.Parse(txtNumero.Text);
            direccion.Piso = int.Parse(txtPiso.Text);
            direccion.Departamento = txtDepartamento.Text;
            direccion.CodigoPostal = txtCodigoPostal.Text;
            direccion.Ciudad = txtCiudad.Text;
            direccion.Pais = txtPais.Text;

            List<DireccionEnvio> listaDirecciones = new List<DireccionEnvio>();
            listaDirecciones.Add(direccion);

            Session["listaDirecciones"] = listaDirecciones;

        }
        protected void Aceptar_Click(object sender, EventArgs e)
        {

        }
    }

}