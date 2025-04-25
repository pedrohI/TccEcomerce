using Microsoft.EntityFrameworkCore;
using TccEcomerce.Models;

namespace TccEcomerce.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    

    // metodo Oncreating para corrigir tipo especificado nas classes ao usar migração para sincronizar com o banco de dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

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