using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }

    [ForeignKey("CanalVenta")]
    public int IdCanal { get; set; }

    [ForeignKey("Tienda")]
    public int IdTienda { get; set; }

    [DisplayName("Fecha del pedido")]
    public DateTime FechaPedido { get; set; }

    [DisplayName("Estado del pedido")]
    public string EstadoPedido { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Total del pedido")]
    public decimal TotalPedido { get; set; }

    public Cliente? Cliente { get; set; }

    public CanalVenta? CanalVenta { get; set; }

    public Tienda? Tienda { get; set; }

    public ICollection<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>();

    public ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public ICollection<Devolucion> Devoluciones { get; set; } = new List<Devolucion>();

    public ICollection<TicketSoporte> TicketsSoporte { get; set; } = new List<TicketSoporte>();

    public ICollection<ReservaStock> ReservasStock { get; set; } = new List<ReservaStock>();
}