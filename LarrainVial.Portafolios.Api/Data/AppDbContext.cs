using LarrainVial.Portafolios.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace LarrainVial.Portafolios.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
}
