namespace Dominio
{
    internal class Venta
    {
        public int Id { get; set; }
        public Carrito Carrito { get; set; }
        public string TipoPago { get; set; } // "EFECTIVO" "TARJETA"
        public string TipoEntrega { get; set; } // "coordinar" "retira por local"

    }
}
