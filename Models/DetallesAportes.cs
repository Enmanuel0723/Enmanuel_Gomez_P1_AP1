﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class AportesDetalles
{
    [Key]
    public int DetalleId { get; set; }

    public int CobroId { get; set; }

    public int PrestamoId { get; set; }

    public double ValorCobrado { get; set; }

    [ForeignKey("CobroId")]
    [InverseProperty("CobrosDetalle")]
    public virtual aportes Aportes { get; set; } = null!;



}