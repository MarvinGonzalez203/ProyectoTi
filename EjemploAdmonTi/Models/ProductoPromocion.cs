using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductoPromocion
{
    [Key]
    public int IdProductoPromocion { get; set; }

    [ForeignKey("Producto")]
    public int IdProducto { get; set; }

    [ForeignKey("Promocion")]
    public int IdPromocion { get; set; }

    public Producto? Producto { get; set; }

    public Promocion? Promocion { get; set; }
}
