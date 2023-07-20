using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace TPC_28
{
    public partial class ResumenDeCompra : System.Web.UI.Page
    {
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }
        private Compra Compra { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["usuario"] != null)
                {
                    Compra = new Compra();
                    Usuario usuario = (Usuario)Session["usuario"];
                    DatosDeArticulos conector = new DatosDeArticulos();
                    ListadoDeArticulos = conector.obtenerArticulosConDetalles();
                    List<ArticulosConDetalles> toShow = new List<ArticulosConDetalles>();
                    CarroConArticulos carro = Session["Cart"] as CarroConArticulos;

                    DireccionEnvio direccion = new DireccionEnvio();
                    direccion.Usuario = usuario;

                    Session["direccionEnvio"] = direccion;

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


                        decimal total = 0;
                        foreach (var item in toShow)
                        {
                            total += item.Precio * item.Cantidad;
                        }

                        Compra.PrecioTotal = total;
                        CargarCarritoACompra(toShow);
                        Session.Add("Compra", Compra);
                        lblTotal.Text = total.ToString("0.00");

                        if (carro != null)
                        {
                            Master.UpdateCartItemCount(carro.GetTotalItems());
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

        private void CargarCarritoACompra(List<ArticulosConDetalles> toShow)
        {
            List<ProductoCompra> l = new List<ProductoCompra>();
            foreach (var item in toShow)
            {
                ProductoCompra productoCompra = new ProductoCompra();
                productoCompra.ArticuloID = item.ArtId;
                productoCompra.Cant = item.Cantidad;
                productoCompra.PrecioCobrado = item.Precio;

                l.Add(productoCompra);
            }
            Compra.ListaProductosEnCompra = l;
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

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] is Usuario usuario)
                {
                    Compra = Session["Compra"] as Compra;
                    DatosDireccionEnvio datosDireccion = new DatosDireccionEnvio();

                    DireccionEnvio direccion = new DireccionEnvio
                    {
                        Usuario = usuario,
                        Calle = txtDomicilio.Text ?? string.Empty,
                        Numero = int.TryParse(txtNumero.Text, out int numero) ? numero : 0,
                        Piso = int.TryParse(txtPiso.Text, out int piso) ? piso : 0,
                        Departamento = txtDepartamento.Text ?? string.Empty,
                        CodigoPostal = txtCodigoPostal.Text ?? string.Empty,
                        Ciudad = txtCiudad.Text ?? string.Empty,
                        Pais = txtPais.Text ?? string.Empty,
                        Descripcion = txtDescripcion.Text ?? string.Empty
                    };

                    usuario.DireccionEnvio = direccion;

                    int formaPagoId = int.Parse(ddlFormaDePago.SelectedValue);
                    Session["FormaPagoId"] = formaPagoId;
                    string descripcionPago = ddlFormaDePago.SelectedItem.Text;

                    Pago pago = new Pago();
                    pago.tipoPago = formaPagoId;

                    Session["usuario"] = usuario;

                    int formaEnvioId = int.Parse(ddlEnvio.SelectedValue);
                    Session["FormaEnvioId"] = formaEnvioId;

                    Envio envio = new Envio();
                    envio.Id = formaEnvioId;

                    Compra.Pago = pago;
                    Compra.Envio = envio;
                    Compra.Usuario = usuario;
                    Compra.Estado = Estado.Pendiente;

                    DatosCompra datosCompra = new DatosCompra();
                    datosCompra.GuardarCompra(Compra);
                    Response.Redirect("MiCuenta.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

