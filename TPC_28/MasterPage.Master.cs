using Dominio;
using System;

namespace TPC_28
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
            if (currentCart != null && currentCart.GetTotalItems() > 0)
            {
                lblItemCountSpan.Style["display"] = "inline-flex;";
            }
            else
            {
                // lblItemCountSpan.Style["display"] = "none";
            }

            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                navbarText.InnerHtml = "Bienvenido, " + user.Nombre;
            }
            else
            {
                navbarText.InnerHtml = "<a class=\"nav-link\" aria-current=\"page\" href=\"Login.aspx\">Logueate!</a>";
            }

        }

        public void UpdateCartItemCount(int itemCount)
        {
            lblItemCount.Text = itemCount.ToString();
            lblItemCountNav.Text = itemCount.ToString();
            lblItemCountSpan.Style["display"] = "inline-flex;";
        }

        public void OcultarFotter()
        {
            footerGlobal.Visible = false;
        }
    }

}