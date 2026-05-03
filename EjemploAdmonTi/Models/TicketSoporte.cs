using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TicketSoporte
{
    [Key]
    public int IdTicket { get; set; }

    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }

    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [ForeignKey("SLA")]
    public int? IdSLA { get; set; }

    [DisplayName("Asunto")]
    public string Asunto { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [DisplayName("Prioridad")]
    public string Prioridad { get; set; } = string.Empty;

    [DisplayName("Estado del ticket")]
    public string EstadoTicket { get; set; } = string.Empty;

    [DisplayName("Fecha de creación")]
    public DateTime FechaCreacion { get; set; }

    public Cliente? Cliente { get; set; }

    public Pedido? Pedido { get; set; }

    public SLA? SLA { get; set; }
}