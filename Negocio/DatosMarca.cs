using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosMarca
    {
        public List<Marca> Listar()
        {
            List<Marca> listaMarca = new List<Marca>();
            AccesoDatos accesoNuevo = new AccesoDatos();

            try
            {
                accesoNuevo.setQuery("select IdMarca as Id, Descripcion as Descripcion from Marcas");
                accesoNuevo.ejecutar();

                while (accesoNuevo.sqlLector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)accesoNuevo.sqlLector["Id"];
                    marca.Descripcion = (string)accesoNuevo.sqlLector["Descripcion"];

                    listaMarca.Add(marca);
                }

                return listaMarca;
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

        public void NuevaMarca(string Nombre)
        {
            AccesoDatos accesoNuevo = new AccesoDatos();
            try
            {
                if (Nombre.Length > 0)
                {
                    accesoNuevo.setQuery("INSERT INTO Marcas (Descripcion) values (@nombre)");
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
                    accesoNuevo.setQuery("DELETE Marcas WHERE IdMarca = @id");
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
