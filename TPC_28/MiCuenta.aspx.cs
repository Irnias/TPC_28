using Dominio;
using System;
using Negocio;
using System.Collections.Generic;


namespace TPC_28
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Inicio.aspx", false);
                }
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblNombre.Text = user.Nombre.ToString();
                    lblApellido.Text = user.Apellido.ToString();
                    lblMail.Text = user.Mail.ToString();

                    DatosDeArticulos conector = new DatosDeArticulos();
                    ListadoDeArticulos = conector.obtenerArticulosConDetalles();
                    List<ArticulosConDetalles> toShow = new List<ArticulosConDetalles>();
                    CarroConArticulos carro = Session["Cart"] as CarroConArticulos;

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


                        repRepetidor.DataSource = toShow;
                        repRepetidor.DataBind();


                        decimal total = 0;
                        foreach (var item in toShow)
                        {
                            total += item.Precio * item.Cantidad;
                        }

                        //lblTotal.Text = total.ToString("0.00");

                        CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
                        if (currentCart != null)
                        {
                            Master.UpdateCartItemCount(currentCart.GetTotalItems());
                        }

                    }
                    if (user.DireccionEnvio != null)
                    {
                        lblCalle.Text = user.DireccionEnvio.Calle;
                        lblNumero.Text = user.DireccionEnvio.Numero.ToString();
                        lblCiudad.Text = user.DireccionEnvio.Ciudad;
                        lblCodigoPostal.Text = user.DireccionEnvio.CodigoPostal;
                        lblPais.Text = user.DireccionEnvio.Pais;

                        lblCalle.Visible = true;
                        lblNumero.Visible = true;
                        lblCiudad.Visible = true;
                        lblCodigoPostal.Visible = true;
                        lblPais.Visible = true;

                        int formaPagoId = (int)Session["FormaPagoId"];
                        formaDePago(formaPagoId);

                        int formaEnvioId = (int)Session["FormaEnvioId"];
                        if (formaEnvioId == 1)
                        {
                            lblTipoEnvio.Text = "Retiro en tienda : Calle Falsa 123 - Tigre - Buenos Aires";


                            lblCalle.Visible = false;
                            lblNumero.Visible = false;
                            lblCiudad.Visible = false;
                            lblCodigoPostal.Visible = false;
                            lblPais.Visible = false;

                        }

                    }

                }

            }


            void formaDePago(int formaPagoId)
            {

                if (formaPagoId == 1)
                {
                    lblFormaPago.Text = "Efectivo";
                }
                else if (formaPagoId == 2)
                {
                    lblFormaPago.Text = "Tarjeta Debito";

                }
                else if (formaPagoId == 3)
                {
                    lblFormaPago.Text = "Tarjeta Credito";

                }
                else
                {
                    lblFormaPago.Text = "Mercado Pago";

                }
            }

        }
    }
}