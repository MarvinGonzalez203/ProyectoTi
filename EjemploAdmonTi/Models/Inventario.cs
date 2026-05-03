using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Inventario
{
    [Key]
    public int IdInventario { get; set; }

    [ForeignKey("Producto")]
    public int IdProducto { get; set; }

    [ForeignKey("Tienda")]
    public int IdTienda { get; set; }

    [ForeignKey("Bodega")]
    public int IdBodega { get; set; }

    [DisplayName("Stock disponible")]
    public int StockDisponible { get; set; }

    [DisplayName("Stock reservado")]
    public int StockReservado { get; set; }

    [DisplayName("Fecha de actualización")]
    public DateTime FechaActualizacion { get; set; }

    public Producto? Producto { get; set; }

    public Tienda? Tienda { get; set; }

    public Bodega? Bodega { get; set; }

    public ICollection<ReservaStock> ReservasStock { get; set; } = new List<ReservaStock>();

    public ICollection<MovimientoInventario> MovimientosInventario { get; set; } = new List<MovimientoInventario>();
}
