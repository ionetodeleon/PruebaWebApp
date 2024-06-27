namespace PruebaWebApp.Models
{
    public class UsuarioProyecto
    {
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        public int IdProyecto { get; set; }
        public Proyecto? Proyecto { get; set; }

    }
}
