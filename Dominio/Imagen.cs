namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int ArtId { get; set; }
        public string ImageUrl { get; set; }

        public Imagen(int id, string description)
        {
            Id = id;
           ImageUrl = description;
        }

        public override string ToString()
        {
            return ImageUrl;
        }

    }
}
