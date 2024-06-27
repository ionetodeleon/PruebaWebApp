namespace PruebaWebApp.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<UsuarioProyecto>? UsuarioProyectos { get; set; }
    }
}
