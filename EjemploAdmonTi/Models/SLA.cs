using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SLA
{
    [Key]
    public int IdSLA { get; set; }

    [ForeignKey("ContratoServicio")]
    public int IdContrato { get; set; }

    [DisplayName("Prioridad")]
    public string Prioridad { get; set; } = string.Empty;

    [DisplayName("Tiempo de respuesta")]
    public string TiempoRespuesta { get; set; } = string.Empty;

    [DisplayName("Tiempo de resolución")]
    public string TiempoResolucion { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    public ContratoServicio? ContratoServicio { get; set; }

    public ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();

    public ICollection<TicketSoporte> TicketsSoporte { get; set; } = new List<TicketSoporte>();
}