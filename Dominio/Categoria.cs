using System;
using System.ComponentModel;

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
        public Categoria()
        {

        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
