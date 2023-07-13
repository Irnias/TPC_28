﻿using Dominio;
using Negocio;
using System;

namespace TPC_28
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((TPC_28.MasterPage)(base.Master)).OcultarFotter();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuario.Mail = txtMail.Text;
                usuario.Contrasenia = txtContrasenia.Text;

                usuario = usuarioNegocio.Logear(usuario);
                if (usuario.UserId > 0)
                {
                    Session.Add("usuario", usuario);
                }
                else
                {
                    Session.Remove("usuario");
                    Session.Add("error", "Usuario o contraseña incorrecto!");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}