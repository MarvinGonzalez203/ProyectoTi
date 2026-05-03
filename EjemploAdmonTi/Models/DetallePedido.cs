using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DetallePedido
{
    [Key]
    public int IdDetallePedido { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [ForeignKey("Producto")]
    public int IdProducto { get; set; }

    [DisplayName("Cantidad")]
    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Precio unitario")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Subtotal")]
    public decimal Subtotal { get; set; }

    public Pedido? Pedido { get; set; }

    public Producto? Producto { get; set; }
}