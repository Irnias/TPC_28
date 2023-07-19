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
        public List<ArticulosConDetalles> ListadoDeArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                DatosDeArticulos conector = new DatosDeArticulos();
                ListadoDeArticulos = conector.obtenerArticulosConDetalles();
                List<ArticulosConDetalles> toShow = new List<ArticulosConDetalles>();
                CarroConArticulos carro = Session["Cart"] as CarroConArticulos;

                if (carro != null)
                {
                    foreach (var item in ListadoDeArticulos)
                    {
                        if (carro.tieneIdArticulo(item.ArtId))
                        {
                            item.Cantidad = carro.GetArticleQuantity(item.ArtId);
                            toShow.Add(item);
                        }
                    }

                    if (!IsPostBack)
                    {
                        repRepetidorCarrito.DataSource = toShow;
                        repRepetidorCarrito.DataBind();
                    }

                    decimal total = 0;
                    foreach (var item in toShow)
                    {
                        total += item.Precio * item.Cantidad;
                    }

                    lblTotal.Text = total.ToString("0.00");

                    CarroConArticulos currentCart = Session["Cart"] as CarroConArticulos;
                    if (currentCart != null)
                    {
                        Master.UpdateCartItemCount(currentCart.GetTotalItems());
                    }
                }
            }
            else
            {
                Session.Add("error", "Tenes que iniciar sesión/registrarte para poder comprar");
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {

        }
    }
    
}