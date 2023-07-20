using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosCompra
    {
        public void GuardarCompra(Compra compra)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setQuery("INSERT INTO Pagos (TipoPago,Estado) OUTPUT Inserted.IdPago VALUES (@TipoPago,@EstadoPago)");
                db.setearParametro("@TipoPago", compra.Pago.tipoPago);
                db.setearParametro("@EstadoPago", EstadoPago.Pendiente.ToString());
                int idNuevoPago = (int)db.EjecutarEscalar();
                db.Cerrar();
                db.ClearQuery();

                DatosEnvios datos = new DatosEnvios();
                int IdEnvio = datos.NuevoEnvio(compra.Envio);

                db.setQuery("INSERT INTO Compras (Envio,Pago,Usuario,PrecioTotal,Estado) OUTPUT Inserted.IdCompra VALUES (@EnvioId,@PagoId,@UsuarioId,@PrecioTotal,@Estado)");
                db.setearParametro("@EnvioId", IdEnvio);
                db.setearParametro("@PagoId", idNuevoPago);
                db.setearParametro("@UsuarioId", compra.Usuario.UserId);
                db.setearParametro("@PrecioTotal", compra.PrecioTotal);
                db.setearParametro("@Estado", compra.Estado.ToString());
                int IdCompraNueva = (int)db.EjecutarEscalar();
                db.ClearQuery();
                foreach (var item in compra.ListaProductosEnCompra)
                {
                    db.setQuery("INSERT INTO ProductosCompra (Compra,Articulo,Cant,PrecioCobrado) VALUES (@Compra,@Articulo,@Cant,@PrecioCobrado)");
                    db.setearParametro("@Compra", IdCompraNueva);
                    db.setearParametro("@Articulo", item.ArticuloID);
                    db.setearParametro("@Cant", item.Cant);
                    db.setearParametro("@PrecioCobrado", item.PrecioCobrado);
                    db.ejecutar();
                    db.ClearQuery();
                    db.ClearParametro();
                    db.Cerrar();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.ClearQuery();
                db.Cerrar();
            }
        }

        public List<Compra> Listar()

        {
            List<Compra> listaCompra = new List<Compra>();
            AccesoDatos accesoNuevo = new AccesoDatos();

            try
            {
                accesoNuevo.setQuery("SELECT  C.IdCompra, C.PrecioTotal, C.Estado AS EstadoCompra, E.CodigoEnvio, E.DireccionEnvio AS IdDireccionEnvio, P.TipoPago FROM Compras C LEFT JOIN Envios E ON C.Envio = E.IdEnvio LEFT JOIN Pagos P ON C.Pago = P.IdPago; ");
                accesoNuevo.ejecutar();

                while (accesoNuevo.sqlLector.Read())
                {
                    Compra compra = new Compra();

                    compra.IdCompra = (!(accesoNuevo.sqlLector["Id"] is DBNull)) ? (int)accesoNuevo.sqlLector["artId"] : 0;
                    compra.InfoExtra = (!(accesoNuevo.sqlLector["Info"] is DBNull)) ? (string)accesoNuevo.sqlLector["Info"] : "";
                    compra.Envio = new Envio
                    (
                        (!(accesoNuevo.sqlLector["CodigoEnvio"] is DBNull)) ? (string)accesoNuevo.sqlLector["CodigoEnvio"] : ""

                    );
                    compra.Envio.DireccionEnvio = new DireccionEnvio
                    (
                     (!(accesoNuevo.sqlLector["NumeroDireccion"] is DBNull)) ? (int)accesoNuevo.sqlLector["NumeroDireccion"] : 0,
                     (!(accesoNuevo.sqlLector["CalleDireccion"] is DBNull)) ? (string)accesoNuevo.sqlLector["CalleDireccion"].ToString() : ""
                    );
                    compra.Pago = new Pago(
                      (!(accesoNuevo.sqlLector["TipoPago"] is DBNull)) ? (int)accesoNuevo.sqlLector["TipoPago"] : 0

                    );

                    listaCompra.Add(compra);
                }

                return listaCompra;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void PasarCompraAPagago(int IdCompra)
        {

        }

        public void PasarCompraAEntregada(int IdCompra)
        {

        }

        public void EliminarCompra(int IdCompra)
        {

        }
    }
}
