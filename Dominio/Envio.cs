namespace Dominio
{
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
