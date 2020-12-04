using GifStore.Data.Enum;
using GifStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GifStore.Data
{
    public class DataContexto : DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(250)");
            }

            modelBuilder.Entity<Cliente>(x =>
            {
            x.ToTable("Clientes");
            x.HasKey(y => y.Id);
            x.Property(y => y.Nome).IsRequired();
            x.Property(y => y.Email).IsRequired();
            x.Property(y => y.Cpf).IsRequired();
            });

        }
    }

}
