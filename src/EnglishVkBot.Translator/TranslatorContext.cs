using EnglishVkBot.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.Translator
{
    public sealed class TranslatorContext: DbContext
    {
        public DbSet<Direction> Directions { get; set; }

        public TranslatorContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Translator.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>()
                .HasIndex(d => new { d.Name, d.Language })
                .IsUnique();
        }
    }
}