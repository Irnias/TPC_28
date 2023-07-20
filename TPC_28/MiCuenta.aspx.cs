using Dominio;
using System;

namespace TPC_28
{
    public partial class MiCuenta : System.Web.UI.Page
    {
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

                        int formaEnvioId = (int)Session["FormaEnvioId"];
                        if (formaEnvioId == 1)
                        {
                            lblTipoEnvio.Text = "Retiro en tienda";


                            lblCalle.Visible = false;
                            lblNumero.Visible = false;
                            lblCiudad.Visible = false;
                            lblCodigoPostal.Visible = false;
                            lblPais.Visible = false;

                        }

                    }

                }
             
            }

        }
    }
}