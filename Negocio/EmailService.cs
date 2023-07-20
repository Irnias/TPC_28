using System;
using System.Net;
using System.Net.Mail;

namespace Negocio
{
    public class EmailService
    {

        private MailMessage Mail;
        private SmtpClient Server;
        private string userName;
        private string password;
        public void EmailSercice()
        {

        }

        public void CrearMail(string destinatario, string asungo, string cuerpo)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setQuery("SELECT userMail, pass FROM MailCredentials WHERE id=1");
                db.ejecutar();
                while (db.sqlLector.Read())
                {
                    userName = (!(db.sqlLector["userMail"] is DBNull)) ? (string)db.sqlLector["userMail"] : "";
                    password = (!(db.sqlLector["pass"] is DBNull)) ? (string)db.sqlLector["pass"] : "";
                }
                Server = new SmtpClient("sandbox.smtp.mailtrap.io", 2525);
                Server.Credentials = new NetworkCredential(userName, password);
                Server.EnableSsl = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }

            Mail = new MailMessage();
            Mail.From = new MailAddress("ayuda@nogal.ar");
            Mail.To.Add(destinatario);
            Mail.Subject = asungo;
            Mail.IsBodyHtml = true;
            Mail.Body = cuerpo;
        }

        public void EnviarMail()
        {
            try
            {
                Server.Send(Mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
