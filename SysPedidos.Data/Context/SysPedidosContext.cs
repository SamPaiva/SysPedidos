using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SysPedidos.Data.Data;
using SysPedidos.Data.Map;
using SysPedidos.Model;

namespace SysPedidos.Data.Context
{
    public class SysPedidosContext : DbContext
    {
        // Criar o banco sem precisar de injeção de dependencia
        public SysPedidosContext(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        /* Creating DatabaseContext configured by Dependency Injection */
        public SysPedidosContext(DbContextOptions<SysPedidosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new PedidoMap());
            builder.ApplyConfiguration(new CardapioMap());

            builder.Entity<Cliente>().ToTable("Clientes");
            builder.Entity<Pedido>().ToTable("Pedidos");
            builder.Entity<Cardapio>().ToTable("Clientes");

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
