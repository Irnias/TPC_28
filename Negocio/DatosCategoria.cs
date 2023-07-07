using Dominio;
using System;
using System.Collections.Generic;

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

        public void NuevaCategoria(string Nombre)
        {
            AccesoDatos accesoNuevo = new AccesoDatos();
            try
            {
                if (Nombre.Length > 0)
                {
                    accesoNuevo.setQuery("INSERT INTO Categorias (Descripcion) values (@nombre)");
                    accesoNuevo.setearParametro("@nombre", Nombre);
                    accesoNuevo.ejecutar();
                }
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

        public void BorradoLogicoPorId(int id)
        {
            AccesoDatos accesoNuevo = new AccesoDatos();
            //TODO agregar columna de borrado loogico
            try
            {
                if (id > 0)
                {
                    accesoNuevo.setQuery("DELETE Categorias WHERE IdCategoria = @id");
                    accesoNuevo.setearParametro("@id", id);
                    accesoNuevo.ejecutar();
                }
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

