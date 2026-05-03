using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reembolso
{
    [Key]
    public int IdReembolso { get; set; }

    [ForeignKey("Devolucion")]
    public int IdDevolucion { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Monto del reembolso")]
    public decimal MontoReembolso { get; set; }

    [DisplayName("Estado del reembolso")]
    public string EstadoReembolso { get; set; } = string.Empty;

    [DisplayName("Fecha del reembolso")]
    public DateTime FechaReembolso { get; set; }

    public Devolucion? Devolucion { get; set; }
}
