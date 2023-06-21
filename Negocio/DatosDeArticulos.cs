﻿using Dominio;
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
                data.setQuery("SELECT A.IdArticulo as artId, A.Nombre as Nombre, A.Descripcion as Descrip, A.DescripcionLarga as DescripLarga, M.IdMarca as idMarca , M.Descripcion as descripMarca, C.IdCategoria as idCat ,C.Descripcion as descripCat, A.Precio as precio,I.IdImagenes as idImagen,  I.ImagenUrl as imgUrl " +
                    "FROM Articulos A, Marcas M, Categorias C, Imagenes I WHERE A.IdMarca = M.IdMarca and A.IdCategoria = C.IdCategoria and A.IdImagen = I.IdArt");
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
                data.setQuery("SELECT A.IdArticulo as artId, A.Nombre as Nombre, A.Descripcion as Descrip, A.DescripcionLarga as DescripLarga, M.IdMarca as idMarca , M.Descripcion as descripMarca, C.IdCategoria as idCat ,C.Descripcion as descripCat, A.Precio as precio,I.IdImagenes as idImagen,  I.ImagenUrl as imgUrl " +
                "FROM Articulos A, Marcas M, Categorias C, Imagenes I WHERE A.IdMarca = M.IdMarca and A.IdCategoria = C.IdCategoria and A.IdImagen = I.IdArt And A.IdArticulo=@id");
                
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
