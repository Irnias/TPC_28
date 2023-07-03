using System;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class DatosDeImagen
    {
        public List<Imagen> FetchImageById(int idArticulo)
        {
            List<Imagen> listaImagen = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("select IdImagenes, IdArt, ImagenUrl from IMAGENES i where IdArt  = " + idArticulo);
                datos.ejecutar();

                while (datos.sqlLector.Read())
                {
                    Imagen aux = new Imagen(
                        (!(datos.sqlLector["IdImagenes"] is DBNull)) ? (int)datos.sqlLector["IdImagenes"] : 0,
                        (!(datos.sqlLector["IdArt"] is DBNull)) ? (int)datos.sqlLector["IdArt"] : 0,
                        (!(datos.sqlLector["ImagenUrl"] is DBNull)) ? (string)datos.sqlLector["ImagenUrl"] : ""
                        );
                    listaImagen.Add(aux);
                }
                return listaImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }

    }


}
