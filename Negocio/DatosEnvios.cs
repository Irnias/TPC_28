using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class DatosEnvios
    {
        public List<Envio> Listar()
        {
            List<Envio> l = new List<Envio>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("select e.CodigoEnvio, t.Descripcion as TipoEnvio, t.IdTipoEnvio, d.Descripcion as AliasDireccion, d.IdDireccionEnvio, u.Mail as UserMail, u.Nombre ,u.Apellido ,u.UserId, e.Estado from Envio e inner join TipoEnvios t on t.IdTipoEnvio = e.TipoEnvio inner join DireccionEnvio d on d.IdDireccionEnvio = e.DireccionEnvio inner join Usuarios u on u.UserId = e.Usuario");
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    Usuario Usuario = new Usuario(
                        (!(db.sqlLector["UserId"] is DBNull)) ? (int)db.sqlLector["UserId"] : 0,
                        (!(db.sqlLector["Nombre"] is DBNull)) ? (string)db.sqlLector["Nombre"] : "",
                        (!(db.sqlLector["Apellido"] is DBNull)) ? (string)db.sqlLector["Apellido"] : "",
                        (!(db.sqlLector["UserMail"] is DBNull)) ? (string)db.sqlLector["UserMail"] : ""
                    );

                    Envio e = new Envio();
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
                db.Cerrar();
            }
        }
        public int NuevoEnvio(Envio e)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                int dirID = (e.DireccionEnvio is null) ? 1 : e.DireccionEnvio.Id;
                db.setQuery("INSERT INTO Envios (CodigoEnvio,TipoEnvio,DireccionEnvio,Usuario,Estado) OUTPUT Inserted.IdEnvio VALUES (@CodigoEnvio,@TipoEnvio,@DireccionEnvio,@Usuario,@Estado)");
                db.setearParametro("@CodigoEnvio", this.GenerarCodigoEnvio());
                db.setearParametro("@TipoEnvio", e.TipoEnvios.Id);
                db.setearParametro("@DireccionEnvio", dirID);
                db.setearParametro("@Usuario", e.Usuario.UserId);
                db.setearParametro("@Estado", EstadoEnvio.Pendiente);

                return db.EjecutarEscalar();
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

        public string GenerarCodigoEnvio()
        {
            StringBuilder sb = new StringBuilder(5);
            Random random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < 5; i++)
            {
                int randomIndex = random.Next(characters.Length);
                char randomChar = characters[randomIndex];
                sb.Append(randomChar);
            }

            return sb.ToString();
        }

    }
}