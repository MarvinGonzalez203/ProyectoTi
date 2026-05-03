using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Devolucion
{
    [Key]
    public int IdDevolucion { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [DisplayName("Motivo de devolución")]
    public string MotivoDevolucion { get; set; } = string.Empty;

    [DisplayName("Fecha de devolución")]
    public DateTime FechaDevolucion { get; set; }

    [DisplayName("Estado de devolución")]
    public string EstadoDevolucion { get; set; } = string.Empty;

    public Pedido? Pedido { get; set; }

    public ICollection<Reembolso> Reembolsos { get; set; } = new List<Reembolso>();
}