using Dominio;
using System;

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
            else if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
            if (currentCart != null)
            {
                ((TPC_28.MasterPage)(base.Master)).UpdateCartItemCount(currentCart.GetTotalItems());
            }
        }

        protected void iniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}