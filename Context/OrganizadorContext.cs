using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("Tarefas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(e => e.Descricao)
                      .HasMaxLength(1000);
                entity.Property(e => e.Data)
                      .IsRequired();
                entity.Property(e => e.Status)
                      .IsRequired()
                      .HasConversion<string>();
            });
        }
    }
}