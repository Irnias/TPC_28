using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosTipoEnvios
    {
        public List<TipoEnvios> Listar()
        {
            List<TipoEnvios> l = new List<TipoEnvios>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("Select IdTipoEnvio AS Id, Descripcion as Descripcion FROM TipoEnvios");
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    TipoEnvios t = new TipoEnvios();
                    t.Id = (int)db.sqlLector["Id"];
                    t.Descripcion = (string)db.sqlLector["Descripcion"];

                    l.Add(t);
                }

                return l;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }

        public void NuevoTipoDeEnvio(string Nombre)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                if (Nombre.Length > 0)
                {
                    db.setQuery("INSERT INTO TipoEnvios (Descripcion) values (@nombre)");
                    db.setearParametro("@nombre", Nombre);
                    db.ejecutar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }

        public void BorradoLogicoPorId(int id)
        {
            AccesoDatos db = new AccesoDatos();
            //TODO agregar columna de borrado logico
            try
            {
                if (id > 0)
                {
                    db.setQuery("DELETE TipoEnvios WHERE IdTipoEnvio = @id");
                    db.setearParametro("@id", id);
                    db.ejecutar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }
    }
}
