using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Promocion
{
    [Key]
    public int IdPromocion { get; set; }

    [DisplayName("Nombre de la promoción")]
    public string NombrePromocion { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Descuento")]
    public decimal Descuento { get; set; }

    [DisplayName("Fecha de inicio")]
    public DateTime FechaInicio { get; set; }

    [DisplayName("Fecha de fin")]
    public DateTime FechaFin { get; set; }

    [DisplayName("Estado")]
    public string Estado { get; set; } = string.Empty;

    public ICollection<ProductoPromocion> ProductosPromociones { get; set; } = new List<ProductoPromocion>();
}
