namespace Dominio
{
    public class TipoEnvios
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoEnvios(int id, string description)
        {
            Id = id;
            Descripcion = description;
        }
        public TipoEnvios()
        {

        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
