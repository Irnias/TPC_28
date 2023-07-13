using Dominio;
using Negocio;
using System;

namespace TPC_28
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((TPC_28.MasterPage)(base.Master)).OcultarFotter();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuario.Mail = txtMail.Text;
                usuario.Contrasenia = txtContrasenia.Text;


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}