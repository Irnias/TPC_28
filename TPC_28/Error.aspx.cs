﻿using System;

namespace TPC_28
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblText.Text = Session["error"].ToString();
                Session.Remove("error");
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}