using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AportesDetalles
{
    [Key]
    public int DetalleId { get; set; }

    [Required]
    public int AporteId { get; set; }

    [Required]
    public decimal MontoDetalle { get; set; }

    [StringLength(150)]
    public string Observacion { get; set; } = string.Empty;

    [ForeignKey("AporteId")]
    [InverseProperty("AportesDetalle")]
    public virtual Aportes Aporte { get; set; } = null!;
}