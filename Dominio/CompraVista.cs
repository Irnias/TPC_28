namespace Dominio
{
    public class CompraVista
    {
        public int IdCompra { get; set; }
        public decimal PrecioTotal { get; set; }
        public string EstadoCompra { get; set; }
        public string CodigoEnvio { get; set; }
        public string DireccionEnvio { get; set; }
    }
}
