using Dominio;

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
