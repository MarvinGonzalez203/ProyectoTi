using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [DisplayName("SKU")]
    public string Sku { get; set; } = string.Empty;

    [DisplayName("Nombre del producto")]
    public string NombreProducto { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [DisplayName("Unidad de medida")]
    public string UnidadMedida { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Precio base")]
    public decimal PrecioBase { get; set; }

    [DisplayName("Estado")]
    public string Estado { get; set; } = string.Empty;

    public ICollection<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>();

    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public ICollection<ReservaStock> ReservasStock { get; set; } = new List<ReservaStock>();

    public ICollection<ProductoPromocion> ProductosPromociones { get; set; } = new List<ProductoPromocion>();
}