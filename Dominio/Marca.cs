namespace Dominio
{
    public class Marca
    {
        public Marca()
        {

        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Marca(int id, string description)
        {
            Id = id;
            Descripcion = description;
        }
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
