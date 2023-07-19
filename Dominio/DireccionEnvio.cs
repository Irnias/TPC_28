namespace Dominio
{
    public class DireccionEnvio
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
    }
}
