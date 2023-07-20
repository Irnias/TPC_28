using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class DatosPagos
    {
        public List<Pagos> Listar()
        {
            List<Pagos> listaPagos = new List<Pagos>();
            AccesoDatos accesoNuevo = new AccesoDatos();

            try
            {
                accesoNuevo.setQuery("select IdPago as Id, TipoPago as Tipo , Estado From Pagos");
                accesoNuevo.ejecutar();

                while (accesoNuevo.sqlLector.Read())
                {
                    Pagos pagos = new Pagos();
                    pagos.idPago = (int)accesoNuevo.sqlLector["Id"];
                    pagos.tipoPago = (int)accesoNuevo.sqlLector["Tipo"];
                    pagos.estado = (string)accesoNuevo.sqlLector["Estado"];

                    listaPagos.Add(pagos);
                }

                return listaPagos;
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
