using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using study_project.model;

namespace study_project.db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Itens> itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Itens>()
                .HasMany(e => e.customers)
                .WithMany(e => e.itens);
        }
    }
}
