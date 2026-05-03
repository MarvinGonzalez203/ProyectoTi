using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Bodega
{
    [Key]
    public int IdBodega { get; set; }

    [DisplayName("Nombre de la bodega")]
    public string NombreBodega { get; set; } = string.Empty;

    [DisplayName("Ubicación")]
    public string Ubicacion { get; set; } = string.Empty;

    [DisplayName("Estado")]
    public string Estado { get; set; } = string.Empty;

    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
