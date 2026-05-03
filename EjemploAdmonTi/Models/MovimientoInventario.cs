using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MovimientoInventario
{
    [Key]
    public int IdMovimiento { get; set; }

    [ForeignKey("Inventario")]
    public int IdInventario { get; set; }

    [DisplayName("Tipo de movimiento")]
    public string TipoMovimiento { get; set; } = string.Empty;

    [DisplayName("Cantidad")]
    public int Cantidad { get; set; }

    [DisplayName("Motivo")]
    public string Motivo { get; set; } = string.Empty;

    [DisplayName("Fecha de movimiento")]
    public DateTime FechaMovimiento { get; set; }

    public Inventario? Inventario { get; set; }
}