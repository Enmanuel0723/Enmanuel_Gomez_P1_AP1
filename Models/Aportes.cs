using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

{
    public class Aportes
    {
        [Key]
        public int CobroId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, double.MaxValue)]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe selecionar un deudor valido")]
        public int DeudorId { get; set; }

        [InverseProperty("Cobro")]
        public virtual ICollection<AportesDetalles> CobrosDetalle { get; set; } = new List<CobrosDetalles>();

        [ForeignKey("DeudorId")]
        [InverseProperty("Cobros")]
        public virtual Deudores Deudor { get; set; } = null!;

    }
}