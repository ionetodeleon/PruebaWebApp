namespace PruebaWebApp.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
