using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TodoApp.Models
{
    public partial class TodoAppContext : DbContext
    {
        public virtual DbSet<Todoes> Todoes { get; set; }

        public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todoes>(entity =>
            {
                entity.HasKey(e => e.TodoId);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Documento).HasMaxLength(500);
            });
        }

    }
}
