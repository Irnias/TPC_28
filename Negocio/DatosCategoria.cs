using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DatosCategoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            AccesoDatos accesoNuevo = new AccesoDatos();

            try
            {
                accesoNuevo.setQuery("Select IdCategoria AS Id, Descripcion as Descripcion FROM Categorias");
                accesoNuevo.ejecutar();

                while (accesoNuevo.sqlLector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.Id = (int)accesoNuevo.sqlLector["Id"];
                    cat.Descripcion = (string)accesoNuevo.sqlLector["Descripcion"];

                    listaCategoria.Add(cat);
                }

                return listaCategoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoNuevo.cerrar();
            }
        }
    }
}

