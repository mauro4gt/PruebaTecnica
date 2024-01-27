using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de Servicio es obligatorio")]
        public string NombreServicio { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        public string Descripcion { get; set; }
    }
}
