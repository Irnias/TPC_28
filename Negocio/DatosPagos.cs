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
        public List<Pago> Listar()
        {
            List<Pago> listaPagos = new List<Pago>();
            AccesoDatos accesoNuevo = new AccesoDatos();

            try
            {
                accesoNuevo.setQuery("select IdPago as Id, TipoPago as Tipo , Estado From Pago");
                accesoNuevo.ejecutar();

                while (accesoNuevo.sqlLector.Read())
                {
                    Pago pagos = new Pago();
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
