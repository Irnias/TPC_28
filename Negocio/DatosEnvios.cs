using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosEnvios
    {
        public List<Envios> Listar()
        {
            List<Envios> l = new List<Envios>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("select e.CodigoEnvio, t.Descripcion as TipoEnvio, t.IdTipoEnvio, d.Descripcion as AliasDireccion, d.IdDireccionEnvio, u.Mail as UserMail, u.Nombre ,u.UserId, e.Estado from Envios e inner join TipoEnvios t on t.IdTipoEnvio = e.TipoEnvio inner join DireccionEnvio d on d.IdDireccionEnvio = e.DireccionEnvio inner join Usuarios u on u.UserId = e.Usuario");
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    Usuario Usuario = new Usuario(
                        (!(db.sqlLector["UserId"] is DBNull)) ? (int)db.sqlLector["UserId"] : 0,
                        (!(db.sqlLector["Nombre"] is DBNull)) ? (string)db.sqlLector["Nombre"] : "",
                        (!(db.sqlLector["UserMail"] is DBNull)) ? (string)db.sqlLector["UserMail"] : ""
                    );

                    Envios e = new Envios();
                    e.CodigoEnvio = (!(db.sqlLector["CodigoEnvio"] is DBNull)) ? (string)db.sqlLector["CodigoEnvio"] : "";
                    e.TipoEnvios = new TipoEnvios(
                        (!(db.sqlLector["IdTipoEnvio"] is DBNull)) ? (int)db.sqlLector["IdTipoEnvio"] : 0,
                        (!(db.sqlLector["TipoEnvio"] is DBNull)) ? (string)db.sqlLector["TipoEnvio"] : ""
                        );
                    e.DireccionEnvio = new DireccionEnvio(
                         (!(db.sqlLector["IdDireccionEnvio"] is DBNull)) ? (int)db.sqlLector["IdDireccionEnvio"] : 0,
                         (!(db.sqlLector["AliasDireccion"] is DBNull)) ? (string)db.sqlLector["AliasDireccion"] : ""
                        );
                    e.Estado = (!(db.sqlLector["CodigoEnvio"] is DBNull)) ? (string)db.sqlLector["CodigoEnvio"] : "";
                    e.Usuario = Usuario;
                    l.Add(e);
                }

                return l;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.cerrar();
            }
        }
    }
}
