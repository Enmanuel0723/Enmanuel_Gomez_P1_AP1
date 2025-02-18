using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Persona { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "La observación no puede superar los 200 caracteres")]
        public string Observacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Monto { get; set; }
    }
}