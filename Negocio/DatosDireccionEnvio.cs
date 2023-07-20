using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosDireccionEnvio
    {
        public List<DireccionEnvio> ListarPorUserId(int id)
        {
            List<DireccionEnvio> l = new List<DireccionEnvio>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("Select IdDireccionEnvio, Descripcion, Calle, Numero, Piso, Departamento, CodigoPostal, Ciudad, Pais FROM DireccionEnvio where Usuario = @id");
                db.setearParametro("@id", id);
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    DireccionEnvio d = new DireccionEnvio();
                    d.Id = (!(db.sqlLector["IdDireccionEnvio"] is DBNull)) ? (int)db.sqlLector["IdDireccionEnvio"] : 0;
                    d.Descripcion = (!(db.sqlLector["Descripcion"] is DBNull)) ? (string)db.sqlLector["Descripcion"] : "";
                    d.Calle = (!(db.sqlLector["Calle"] is DBNull)) ? (string)db.sqlLector["Calle"] : "";
                    d.Numero = (!(db.sqlLector["Numero"] is DBNull)) ? (int)db.sqlLector["Numero"] : 0;
                    d.Piso = (!(db.sqlLector["Piso"] is DBNull)) ? (int)db.sqlLector["Piso"] : 0;
                    d.Departamento = (!(db.sqlLector["Departamento"] is DBNull)) ? (string)db.sqlLector["Departamento"] : "";
                    d.CodigoPostal = (!(db.sqlLector["CodigoPostal"] is DBNull)) ? (string)db.sqlLector["CodigoPostal"] : "";
                    d.Ciudad = (!(db.sqlLector["Ciudad"] is DBNull)) ? (string)db.sqlLector["Ciudad"] : "";
                    d.Pais = (!(db.sqlLector["Pais"] is DBNull)) ? (string)db.sqlLector["Pais"] : "";
                    l.Add(d);
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
        public void NuevaDireccionDeEnvio(DireccionEnvio DirEnvio)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {

                db.setQuery("INSERT INTO DireccionEnvio (Descripcion,  Calle,  Numero,  Piso,  Departamento,  CodigoPostal,  Ciudad,  Pais) values " +
                                                      "(@Descripcion, @Calle, @Numero, @Piso, @Departamento, @CodigoPostal, @Ciudad, @Pais)");

                db.setearParametro("@Descripcion", DirEnvio.Descripcion);
                db.setearParametro("@Calle", DirEnvio.Calle);
                db.setearParametro("@Numero", DirEnvio.Numero);
                db.setearParametro("@Piso", DirEnvio.Piso);
                db.setearParametro("@Departamento", DirEnvio.Departamento);
                db.setearParametro("@CodigoPostal", DirEnvio.CodigoPostal);
                db.setearParametro("@Ciudad", DirEnvio.Ciudad);
                db.setearParametro("@Pais", DirEnvio.Pais);
                db.ejecutar();
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
