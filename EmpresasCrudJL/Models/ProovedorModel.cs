using System.ComponentModel.DataAnnotations;

namespace EmpresasCrudJL.Models
{
    public class ProovedorModel
    {
        public int Clave_P { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo RFC es obligatorio")]
        public string? RFC { get; set; }
        [Required(ErrorMessage = "El campo Ciudad es obligatorio")]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion { get; set; }
    }
}
