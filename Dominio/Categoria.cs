namespace Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Categoria(int id, string description)
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
