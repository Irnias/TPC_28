using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

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
        }

        public void UpdateCartItemCount(int itemCount)
        {
            lblItemCount.Text = itemCount.ToString();
            lblItemCountNav.Text = itemCount.ToString();
            lblItemCountSpan.Style["display"] = "inline-flex;";
        }
    }

}