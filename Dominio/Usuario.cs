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
        public Carro Carro { get; set; }  


        public Usuario(string Nom, string Ape, string Pass, string Email)
        {
            Nombre = Nom;
            Apellido = Ape;
            Contrasenia = Pass;
            Mail = Email;
            TipoUsuario = TipoUsuario.Normal;
        }

        public Usuario()
        {
            UserId = 0;
            Carro = new Carro();
        }


    }

}
