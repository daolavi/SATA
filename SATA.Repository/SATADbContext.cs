using Microsoft.EntityFrameworkCore;
using SATA.Repository.Entities;

namespace SATA.Repository
{
    public class SATADbContext : DbContext
    {
        public SATADbContext(DbContextOptions<SATADbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Card");
        }
    }
}
