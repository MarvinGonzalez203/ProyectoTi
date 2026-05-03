using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Tienda
{
    [Key]
    public int IdTienda { get; set; }

    [DisplayName("Nombre de la tienda")]
    public string NombreTienda { get; set; } = string.Empty;

    [DisplayName("Dirección")]
    public string Direccion { get; set; } = string.Empty;

    [DisplayName("Teléfono")]
    public string Telefono { get; set; } = string.Empty;

    [DisplayName("Estado")]
    public string Estado { get; set; } = string.Empty;

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}