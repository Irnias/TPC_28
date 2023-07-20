namespace Dominio
{
    public enum EstadoPago
    {
        Pendiente,
        Pagado,
        Rechazado,
        Devuelto
    }
    public class Pago
    {
        public int idPago { get; set; }
        public int tipoPago { get; set; }
        public string estado { get; set; }

    }
}
