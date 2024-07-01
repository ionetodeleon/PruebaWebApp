using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaWebApp.Models
{
    public class Oficina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        [ForeignKey("Usuarios")]
        [Display(Name = "Usuario Responsable")]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
