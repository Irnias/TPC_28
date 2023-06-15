namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Marca(int id, string description)
        {
            Id = id;
            Descripcion = description;
        }
    }
}
