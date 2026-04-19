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

    }
}

