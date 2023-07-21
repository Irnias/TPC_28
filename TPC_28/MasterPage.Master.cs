using Dominio;
using System;
using System.Web.UI.HtmlControls;

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

                string userHtml = @"
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown' aria-expanded='false'> Bienvenido, " + user.Nombre + @"
                        </a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='MiCuenta.aspx'>Mi Cuenta</a></li>
                            <li><a class='dropdown-item' href='Logout.aspx'>Logout</a></li>
                        </ul>
                    </li>";

                HtmlGenericControl userLi = new HtmlGenericControl("li");
                userLi.InnerHtml = userHtml;
                userDropdown.Controls.Add(userLi);

                if (user.TipoUsuario == TipoUsuario.SuperAdmin)
                {
                    string html = @"
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown' aria-expanded='false'>Configuraciones
                        </a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='ListadoDeArticulos.aspx'>Listado De Articulos</a></li>
                            <li><a class='dropdown-item' href='ListadoDeMarcas.aspx'>Marcas</a></li>
                            <li><a class='dropdown-item' href='ListadoDeCategorias.aspx'>Categorias</a></li>
                            <li><a class='dropdown-item' href='ListadoDeTiposDePago.aspx'>Tipos De Pagos</a></li>
                            <li><a class='dropdown-item' href='MisVentas.aspx'>Mis Ventas</a></li>
                            <li><a class='dropdown-item' href='#'>Usuarios</a></li>
                        </ul>
                    </li>";

                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.InnerHtml = html;
                    dropdownMenu.Controls.Add(li);
                }
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