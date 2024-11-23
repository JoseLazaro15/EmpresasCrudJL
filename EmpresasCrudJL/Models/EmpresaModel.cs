using System.ComponentModel.DataAnnotations;

namespace EmpresasCrudJL.Models
{
    public class EmpresaModel
    {
        public int CIF { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo localidad es obligatorio")]
        public string? Localidad { get; set; }
        [Required(ErrorMessage = "El campo provincia es obligatorio")]
        public string? Provincia { get; set; }
        [Required(ErrorMessage = "El campo dirección es obligatorio")]
        public string? Direccion { get; set; }
    }
}
