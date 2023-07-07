using System;
using System.ComponentModel;

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

        public Imagen()
        {

        }
        public Imagen(int Id, int idArticulo, string ImageUrl)
        {
            this.Id = Id;
            this.ArtId = idArticulo;
            this.ImageUrl = ImageUrl;
        }


        public override string ToString()
        {
            return ImageUrl;
        }


    }
}
