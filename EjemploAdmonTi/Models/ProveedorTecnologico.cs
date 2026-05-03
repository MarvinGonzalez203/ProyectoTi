using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploAdmonTi.Models
{
    public class ProveedorTecnologico
    {
        [Key]
        public int IdProveedor { get; set; }

        [DisplayName("Nombre del proveedor")]
        public string NombreProveedor { get; set; } = string.Empty;

        [DisplayName("Servicio del proveedor")]
        public string ServicioProveedor { get; set; } = string.Empty;

        [DisplayName("Correo de contacto")]
        public string CorreoContacto { get; set; } = string.Empty;

        [DisplayName("Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        public ICollection<ContratoServicio> ContratosServicio { get; set; } = new List<ContratoServicio>();
    }
 }