using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pago
{
    [Key]
    public int IdPago { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [DisplayName("Método de pago")]
    public string MetodoPago { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Monto pagado")]
    public decimal MontoPagado { get; set; }

    [DisplayName("Estado del pago")]
    public string EstadoPago { get; set; } = string.Empty;

    [DisplayName("Fecha de pago")]
    public DateTime FechaPago { get; set; }

    public Pedido? Pedido { get; set; }
}