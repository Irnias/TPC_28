using System;

namespace TPC_28
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Remove("usuario");
            }
            Response.Redirect("Inicio.aspx", false);
        }
    }
}
