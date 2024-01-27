using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre de Cliente es obligatorio")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Correo es obligatorio")]
        public string Correo { get; set; }
    }
}
