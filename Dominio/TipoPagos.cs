namespace Dominio
{
    public class TipoPagos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoPagos(int id, string description)
        {
            Id = id;
            Descripcion = description;
        }
        public TipoPagos()
        {

        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
