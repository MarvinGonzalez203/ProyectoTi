using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EjemploAdmonTi.Models
{
    public class AppDbContext :
        IdentityDbContext<IdentityUser>
    {

        public AppDbContext
          (DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<ProveedorTecnologico> ProveedoresTecnologicos { get; set; }
        public DbSet<ContratoServicio> ContratosServicios { get; set; }
        public DbSet<SLA> SLAs { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CanalVenta> CanalVentas { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<TicketSoporte> TicketSoportes { get; set; }

        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<Reembolso> Reembolsos { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<ReservaStock> ReservaStocks { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }

        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<ProductoPromocion> ProductoPromociones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relacion in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relacion.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}

