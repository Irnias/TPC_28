namespace Dominio
{
    public class ProductoCompra
    {
        public int IdProductosCompra { get; set; }
        public int IdCompra { get; set; }
        public int ArticuloID { get; set; }
        public int Cant { get; set; }
        public decimal PrecioCobrado { get; set; }
    }
}
