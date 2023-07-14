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
            if (Session["usuario"] != null)
            {
                Response.Redirect("Inicio.aspx", false);
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuario.Mail = txtMail.Text;
                usuario.Contrasenia = txtContrasenia.Text;
                usuario.TipoUsuario = TipoUsuario.Normal;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                if (txtContrasenia.Text != txtContrasenia2.Text)
                {
                    txtContrasenia2.CssClass = "form-control form-control-lg is-invalid";
                    lblFeedback2.Visible = true;
                    return;
                }
                else
                {
                    txtContrasenia2.CssClass = "form-control form-control-lg";
                    lblFeedback2.Visible = false;
                }

                if (!usuarioNegocio.EstaElMailDisponible(usuario.Mail))
                {
                    txtMail.CssClass = "form-control form-control-lg is-invalid";
                    lblFeedback.Visible = true;
                    return;
                }

                usuarioNegocio.Registrar(usuario);
                Session.Add("usuario", usuario);
                Response.Redirect("Inicio.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}