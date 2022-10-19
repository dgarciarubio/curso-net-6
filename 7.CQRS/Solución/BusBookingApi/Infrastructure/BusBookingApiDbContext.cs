namespace BusBookingApi.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    public class BusBookingApiDbContext : DbContext
    {
        public BusBookingApiDbContext(DbContextOptions<BusBookingApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes.Commands.Cliente> Clientes => Set<Clientes.Commands.Cliente>();
        public DbSet<Rutas.Commands.Ruta> Rutas => Set<Rutas.Commands.Ruta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClienteEntityConfiguration().Configure(modelBuilder.Entity<Clientes.Commands.Cliente>());
            new RutaEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Commands.Ruta>());
            new ViajeEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Commands.Viaje>());
            new AsientoEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Commands.Asiento>());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteEntityConfiguration).Assembly);
        }
    }
}
