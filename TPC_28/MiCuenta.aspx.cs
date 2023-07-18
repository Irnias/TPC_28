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
                }
            }

        }
    }
}