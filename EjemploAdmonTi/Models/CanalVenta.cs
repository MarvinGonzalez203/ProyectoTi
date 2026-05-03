using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class CanalVenta
{
    [Key]
    public int IdCanal { get; set; }

    [DisplayName("Nombre del canal")]
    public string NombreCanal { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}