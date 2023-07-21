namespace Dominio
{
    public enum TipoUsuario
    {
        Normal = 1,
        SuperAdmin = 99,
    }
    public class Usuario
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public string Mail { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public ArtDentroDelCarrito Carro { get; set; }
        public DireccionEnvio DireccionEnvio { get; set; }
        public TipoPagos pagos { get; set; }

        public Usuario(string Nom, string Ape, string Pass, string Email)
        {
            Nombre = Nom;
            Apellido = Ape;
            Contrasenia = Pass;
            Mail = Email;
            TipoUsuario = TipoUsuario.Normal;
        }

        public Usuario(int id, string N, string A, string M)
        {
            UserId = id;
            Nombre = N;
            Apellido = A;
            Mail = M;
        }

        public Usuario()
        {
            UserId = 0;
            Carro = new ArtDentroDelCarrito();
        }



    }

}
