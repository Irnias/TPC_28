using Dominio;
using System;
using System.Collections.Generic;

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



        public Imagen ListarConId(int id)
        {
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("select Id, IdArticulo, ImagenUrl from IMAGENES where IdArticulo  = " + id);
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    Imagen aux = new Imagen(
                        (!(db.sqlLector["IdImagenes"] is DBNull)) ? (int)db.sqlLector["IdImagenes"] : 0,
                        (!(db.sqlLector["IdArt"] is DBNull)) ? (int)db.sqlLector["IdArt"] : 0,
                        (!(db.sqlLector["ImagenUrl"] is DBNull)) ? (string)db.sqlLector["ImagenUrl"] : ""
                        );
                    return aux;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Imagen GetFirstImageById(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT TOP 1 IdArt, ImagenUrl FROM IMAGENES WHERE IdArt = " + idArticulo);
                datos.ejecutar();

                if (datos.sqlLector.Read())
                {
                    Imagen aux = new Imagen(
                        (!(datos.sqlLector["IdArt"] is DBNull)) ? (int)datos.sqlLector["IdArt"] : 0,
                        (!(datos.sqlLector["ImagenUrl"] is DBNull)) ? (string)datos.sqlLector["ImagenUrl"] : ""
                    );
                    return aux;
                }

                return null;
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
