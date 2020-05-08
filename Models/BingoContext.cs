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
                .HasKey(c => new { c.CardNumber, c.Number });

            modelBuilder.Entity<BingoNumber>()
                .HasOne(c => c.Card)
                .WithMany(c => c.Numbers);

            modelBuilder.Entity<BingoCard>()
                .HasKey(c => c.CardNumber);

            modelBuilder.Entity<BingoCard>()
                .Property(c => c.CardNumber)
                .UseIdentityColumn();

            modelBuilder.Entity<BingoGameNumber>()
                .HasKey(c => new { c.GameNumber, c.Number });

            modelBuilder.Entity<BingoGameNumber>()
                .HasOne(c => c.Game)
                .WithMany(c => c.Numbers);
            
            modelBuilder.Entity<BingoGameNumber>()
                .Property(c => c.DrawTime)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BingoGame>()
                .HasKey(c => c.GameNumber);

            modelBuilder.Entity<BingoGame>()
                .Property(c => c.GameNumber)
                .UseIdentityColumn();

            modelBuilder.Entity<BingoGame>()
                .Property(c => c.DateCreated)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
        }

        public DbSet<BingoCard> Cards { get; set; }

        public DbSet<BingoNumber> Numbers { get; set; }

        public DbSet<BingoGame> Games { get; set; }

        public DbSet<BingoGameNumber> GameNumbers { get; set; }
    }
}