namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int ArtId { get; set; }
        public string ImageUrl { get; set; }

        public Imagen(string description)
        {
           
           ImageUrl = description;
        }
    }
}
