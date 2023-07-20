namespace Dominio
{
    public enum FormaEnvio
    {
        Retiro = 1,
        Domicilio = 2,
    }
    public enum EstadoEnvio
    {
        Pendiente,
        EnCamino,
        Entregago
    }
    public class Envio
    {
        public int Id { get; set; }
        public string CodigoEnvio { get; set; }
        public TipoEnvios TipoEnvios { get; set; }
        public DireccionEnvio DireccionEnvio { get; set; }
        public Usuario Usuario { get; set; }
        public string Estado { get; set; }
    }
}
