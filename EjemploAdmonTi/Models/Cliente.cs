using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [DisplayName("Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [DisplayName("Teléfono")]
    public string Telefono { get; set; } = string.Empty;

    [DisplayName("Correo")]
    public string Correo { get; set; } = string.Empty;

    [DisplayName("Dirección")]
    public string Direccion { get; set; } = string.Empty;

    [DisplayName("Fecha de registro")]
    public DateTime FechaRegistro { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public ICollection<TicketSoporte> TicketsSoporte { get; set; } = new List<TicketSoporte>();
}