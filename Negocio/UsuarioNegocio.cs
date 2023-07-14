using Dominio;
using System;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool EstaElMailDisponible(string mail)
        {
            AccesoDatos d = new AccesoDatos();
            try
            {
                d.setQuery("SELECT UserId from Usuarios WHERE Mail = @mail");
                d.setearParametro("@mail", mail);
                d.ejecutar();
                while (d.sqlLector.Read())
                {
                    int UserId = (!(d.sqlLector["UserId"] is DBNull)) ? (int)d.sqlLector["UserId"] : 0;

                    return UserId == 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                d.cerrar();
            }

            return true;
        }

        public Usuario Logear(Usuario Usuario)
        {
            AccesoDatos d = new AccesoDatos();
            try
            {
                d.setQuery("SELECT UserId, Nombre, Apellido, TipoUsuario FROM Usuarios WHERE Mail = @mail AND Contrasenia = @pass");
                d.setearParametro("@mail", Usuario.Mail);
                d.setearParametro("@pass", Usuario.Contrasenia);

                d.ejecutar();
                while (d.sqlLector.Read())
                {
                    Usuario.UserId = (!(d.sqlLector["UserId"] is DBNull)) ? (int)d.sqlLector["UserId"] : 0;
                    Usuario.TipoUsuario = (!(d.sqlLector["TipoUsuario"] is DBNull)) ? (int)d.sqlLector["TipoUsuario"] == 99 ? TipoUsuario.SuperAdmin : TipoUsuario.Normal : 0;
                    Usuario.Nombre = (!(d.sqlLector["Nombre"] is DBNull)) ? (string)d.sqlLector["Nombre"] : "";
                    Usuario.Apellido = (!(d.sqlLector["Apellido"] is DBNull)) ? (string)d.sqlLector["Apellido"] : "";
                    return Usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                d.cerrar();
            }
            return new Usuario();
        }

        public bool Registrar(Usuario usuario)
        {
            AccesoDatos d = new AccesoDatos();
            try
            {
                d.setQuery("insert into Usuarios(Nombre, Apellido, Mail, Contrasenia, TipoUsuario) values (@n, @a, @m, @c, @t)");
                d.setearParametro("@n", usuario.Nombre);
                d.setearParametro("@a", usuario.Apellido);
                d.setearParametro("@m", usuario.Mail);
                d.setearParametro("@c", usuario.Contrasenia);
                d.setearParametro("@t", usuario.TipoUsuario);
                d.ejecutar();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                d.cerrar();
            }
        }
    }
}
