using System.Collections.Generic;
namespace Dominio
{

    public enum Estado
    {
        Pendiente,
        EnProceso,
        Completado
    }

    public class Compra
    {
        public int IdCompra { get; set; }
        public string InfoExtra { get; set; }
        public Envio Envio { get; set; }
        public Pago Pago { get; set; }
        public Usuario Usuario { get; set; }
        public decimal PrecioTotal { get; set; }
        public Estado Estado { get; set; }
        public List<ProductoCompra> ListaProductosEnCompra { get; set; }
    }
}
