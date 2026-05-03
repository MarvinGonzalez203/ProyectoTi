using EjemploAdmonTi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ContratoServicio
{
    [Key]
    public int IdContrato { get; set; }

    [ForeignKey("ProveedorTecnologico")]
    public int IdProveedor { get; set; }

    [DisplayName("Fecha de inicio")]
    public DateTime FechaInicio { get; set; }

    [DisplayName("Fecha de fin")]
    public DateTime FechaFin { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Monto de implementación")]
    public decimal MontoImplementacion { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayName("Monto mensual")]
    public decimal MontoMensual { get; set; }

    [DisplayName("Estado del contrato")]
    public string EstadoContrato { get; set; } = string.Empty;

    public ProveedorTecnologico? ProveedorTecnologico { get; set; }

    public ICollection<SLA> SLAs { get; set; } = new List<SLA>();
}
