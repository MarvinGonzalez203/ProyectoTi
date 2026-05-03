using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReservaStock
{
    [Key]
    public int IdReserva { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [ForeignKey("Producto")]
    public int IdProducto { get; set; }

    [ForeignKey("Inventario")]
    public int IdInventario { get; set; }

    [DisplayName("Cantidad reservada")]
    public int CantidadReservada { get; set; }

    [DisplayName("Fecha de reserva")]
    public DateTime FechaReserva { get; set; }

    [DisplayName("Estado de reserva")]
    public string EstadoReserva { get; set; } = string.Empty;

    public Pedido? Pedido { get; set; }

    public Producto? Producto { get; set; }

    public Inventario? Inventario { get; set; }
}

