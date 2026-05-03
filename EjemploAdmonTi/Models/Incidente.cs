using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Incidente
{
    [Key]
    public int IdIncidente { get; set; }

    [ForeignKey("SLA")]
    public int IdSLA { get; set; }

    [DisplayName("Tipo de incidente")]
    public string TipoIncidente { get; set; } = string.Empty;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [DisplayName("Estado del incidente")]
    public string EstadoIncidente { get; set; } = string.Empty;

    [DisplayName("Fecha de inicio")]
    public DateTime FechaInicio { get; set; }

    [DisplayName("Fecha de cierre")]
    public DateTime? FechaCierre { get; set; }

    public SLA? SLA { get; set; }
}
