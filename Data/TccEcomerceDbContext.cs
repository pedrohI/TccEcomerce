using Microsoft.EntityFrameworkCore;
using TccEcomerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TccEcomerce.Data
{

    public class TccEcomerceDbContext : IdentityDbContext<Usuario>
    {
        // Construtor que recebe as opções de configuração do DbContext
        public TccEcomerceDbContext(DbContextOptions<TccEcomerceDbContext> options) : base(options)
        {
        }
        // Propriedades DbSet para cada entidade do modelo

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public IEnumerable<object> Produto { get; internal set; }


        // metodo Oncreating para corrigir tipo especificado nas classes ao usar migração para sincronizar com o banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.Property(e => e.PrecoUnitario)
                      .HasColumnType("decimal(18,4)"); // Exemplo de maior precisão
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.ValorTotal)
                      .HasColumnType("decimal(18,4)"); // Exemplo de maior precisão
            });
        }

    }
}