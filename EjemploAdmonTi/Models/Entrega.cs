using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Entrega
{
    [Key]
    public int IdEntrega { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [DisplayName("Tipo de entrega")]
    public string TipoEntrega { get; set; } = string.Empty;

    [DisplayName("Dirección de entrega")]
    public string DireccionEntrega { get; set; } = string.Empty;

    [DisplayName("Fecha programada")]
    public DateTime FechaProgramada { get; set; }

    [DisplayName("Estado de entrega")]
    public string EstadoEntrega { get; set; } = string.Empty;

    public Pedido? Pedido { get; set; }
}
