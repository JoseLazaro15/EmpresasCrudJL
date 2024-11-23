using System.ComponentModel.DataAnnotations;

namespace EmpresasCrudJL.Models
{
    public class JugadorModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo Nombre Completo es obligatorio")]
        public string? NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo Numero es obligatorio")]
        public int? Numero { get; set; }
        [Required(ErrorMessage = "El campo Equipo es obligatorio")]
        public string? Equipo { get; set; }
        [Required(ErrorMessage = "El campo Alias es obligatorio")]
        public string? Alias { get; set; }
        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? Estado { get; set; }
    }
}
