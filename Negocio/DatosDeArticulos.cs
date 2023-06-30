using Dominio;
using System;
using System.Collections.Generic;


namespace Negocio
{
    public class DatosDeArticulos
    {

        public List<Articulo> Listar()
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                string Query = "SELECT A.IdArticulo as artId, A.Nombre as nombre, A.Descripcion as descrip, A.DescripcionLarga as DescripLarga,M.IdMarca as idMarca, M.Descripcion as descripMarca, " +
                    "C.IdCategoria as idCat,C.Descripcion as descripCat, A.Precio as precio, I.IdImagenes as idImagen, I.ImagenUrl as imgUrl FROM Articulos A " +
                    "inner join Marcas M on A.IdMarca = M.IdMarca left join Imagenes I on A.IdArticulo = I.IdArt inner join Categorias C on A.IdCategoria = C.IdCategoria";

                data.setQuery(Query);
                data.ejecutar();

                while (data.sqlLector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ArtId = (!(data.sqlLector["artId"] is DBNull)) ? (int)data.sqlLector["artId"] : 0;
                    aux.Nombre = (!(data.sqlLector["nombre"] is DBNull)) ? (string)data.sqlLector["nombre"] : "";
                    aux.Descripcion = (!(data.sqlLector["descrip"] is DBNull)) ? (string)data.sqlLector["descrip"] : "";
                    aux.DescripcionLarga = (!(data.sqlLector["DescripLarga"] is DBNull)) ? (string)data.sqlLector["DescripLarga"] : "";
                    aux.Precio = (!(data.sqlLector["precio"] is DBNull)) ? (decimal)data.sqlLector["precio"] : 0;
                    aux.Categoria = new Categoria(
                        (!(data.sqlLector["idCat"] is DBNull)) ? (int)data.sqlLector["idCat"] : 0,
                        (!(data.sqlLector["descripCat"] is DBNull)) ? (string)data.sqlLector["descripCat"] : ""
                        );
                    aux.Marca = new Marca(
                        (!(data.sqlLector["idMarca"] is DBNull)) ? (int)data.sqlLector["idMarca"] : 0,
                        (!(data.sqlLector["descripMarca"] is DBNull)) ? (string)data.sqlLector["descripMarca"] : ""
                        );
                    aux.Imagenes = new Imagen(
                        (!(data.sqlLector["idImagen"] is DBNull)) ? (int)data.sqlLector["idImagen"] : 0,
                        (!(data.sqlLector["imgUrl"] is DBNull)) ? (string)data.sqlLector["imgUrl"] : ""
                        );

                    ListaArticulos.Add(aux);
                }
                return ListaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrar();
            }
        }

        public Articulo ListarConId(int id)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("SELECT A.IdArticulo AS artId, A.Nombre AS nombre, A.Descripcion AS descrip, A.DescripcionLarga AS DescripLarga, M.IdMarca AS idMarca, " +
                    "M.Descripcion AS descripMarca, C.IdCategoria AS idCat, C.Descripcion AS descripCat, A.Precio AS precio, I.IdImagenes as idImagen, I.ImagenUrl as imgUrl FROM Articulos A INNER JOIN " +
                    "Marcas M ON A.IdMarca = M.IdMarca INNER JOIN Categorias C ON A.IdCategoria = C.IdCategoria INNER JOIN Imagenes I ON A.IdArticulo = I.IdArt WHERE A.IdArticulo = @id;");
                
                data.setearParametro("@id", id);

                data.ejecutar();

                while (data.sqlLector.Read())
                {

                    Articulo aux = new Articulo();
                    aux.ArtId = (!(data.sqlLector["artId"] is DBNull)) ? (int)data.sqlLector["artId"] : 0;
                    aux.Nombre = (!(data.sqlLector["nombre"] is DBNull)) ? (string)data.sqlLector["nombre"] : "";
                    aux.Descripcion = (!(data.sqlLector["descrip"] is DBNull)) ? (string)data.sqlLector["descrip"] : "";
                    aux.DescripcionLarga = (!(data.sqlLector["DescripLarga"] is DBNull)) ? (string)data.sqlLector["DescripLarga"] : "";
                    aux.Precio = (!(data.sqlLector["precio"] is DBNull)) ? (decimal)data.sqlLector["precio"] : 0;
                    aux.Categoria = new Categoria(
                        (!(data.sqlLector["idCat"] is DBNull)) ? (int)data.sqlLector["idCat"] : 0,
                        (!(data.sqlLector["descripCat"] is DBNull)) ? (string)data.sqlLector["descripCat"] : ""
                        );
                    aux.Marca = new Marca(
                        (!(data.sqlLector["idMarca"] is DBNull)) ? (int)data.sqlLector["idMarca"] : 0,
                        (!(data.sqlLector["descripMarca"] is DBNull)) ? (string)data.sqlLector["descripMarca"] : ""
                        );
                    aux.Imagenes = new Imagen(
                        (!(data.sqlLector["idImagen"] is DBNull)) ? (int)data.sqlLector["idImagen"] : 0,
                        (!(data.sqlLector["imgUrl"] is DBNull)) ? (string)data.sqlLector["imgUrl"] : ""
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

        public void eliminarConSp(Articulo idArticulo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearSp("SP_EliminarArticulos");
                data.setearParametro("@id", idArticulo.ArtId);

                data.ejecutar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void modificarConSp(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearSp("SP_ModificarArticulos");
                data.setearParametro("@id", articulo.ArtId);
                data.setearParametro("@Nombre", articulo.Nombre);
                data.setearParametro("@Descripcion", articulo.Descripcion);
                data.setearParametro("@DescripcionLarga", articulo.DescripcionLarga);
                data.setearParametro("@IdMarca", articulo.Marca.Id);
                data.setearParametro("@IdCategoria", articulo.Categoria.Id);
                data.setearParametro("@IdImagen", articulo.Imagenes.Id);
                data.setearParametro("@Precio", articulo.Precio);
                // data.setearParametro("@Calificacion", articulo.Calificacion);
                // data.setearParametro("@UrlImagen", articulo.Imagenes.ImageUrl);

                data.ejecutar();

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void agregarConSp(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearSp("SP_AltaArticulos");
                data.setearParametro("@Nombre", articulo.Nombre);
                data.setearParametro("@Descripcion", articulo.Descripcion);
                data.setearParametro("@DescripcionLarga", articulo.DescripcionLarga);
                data.setearParametro("@IdMarca", articulo.Marca.Id);
                data.setearParametro("@IdCategoria", articulo.Categoria.Id);
                data.setearParametro("@IdImagen", articulo.Imagenes.Id);
                data.setearParametro("@Precio", articulo.Precio);
                // data.setearParametro("@Calificacion", articulo.Calificacion);
                // data.setearParametro("@UrlImagen", articulo.Imagenes.ImageUrl);

                data.ejecutar();




            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
