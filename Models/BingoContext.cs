using Bingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bingo
{
    public class BingoContext : DbContext
    {
        public BingoContext(DbContextOptions<BingoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BingoNumber>()
                .HasOne(c => c.Card);

            modelBuilder.Entity<BingoNumber>()
                .HasKey(c => new {c.CardNumber, c.Number});

            modelBuilder.Entity<BingoCard>()
                .Property(c => c.CardNumber)
                .UseIdentityColumn();
        }

        public DbSet<BingoCard> Cards { get; set; }

        public DbSet<BingoNumber> Numbers { get; set; }
    }
}