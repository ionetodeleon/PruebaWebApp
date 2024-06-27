using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaWebApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Display(Prompt = "Ingrese su nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Prompt = "Ingrese su apellido")]
        [Required(ErrorMessage = "El apellido es requerido")]

        public string Apellido { get; set; }
        [Display(Name = "Cedula de identidad", Prompt = "Ingrese su cedula")]
        [Required(ErrorMessage = "La cedula es requerida")]
        public string Cedula { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es necesaria")]
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public ICollection<UsuarioProyecto>? UsuarioProyectos { get; set; }
        public Oficina? Oficina { get; set; }
    }
}
