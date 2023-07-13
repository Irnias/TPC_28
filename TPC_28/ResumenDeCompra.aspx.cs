using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_28
{
    public partial class ResumenDeCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

     
    }
    
}