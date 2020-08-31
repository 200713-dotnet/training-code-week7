using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astroflix.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Astroflix.DataAccess
{
  public class AstroflixContext : DbContext
  {
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }

    public AstroflixContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<MovieEntity>().HasKey(e => e.Id);
      builder.Entity<GenreEntity>().HasKey(e => e.Id);
      builder.Entity<GenreEntity>().HasMany<MovieEntity>(e => e.Movies).WithOne(e => e.Genre);

      Seed(builder);
    }

    private void Seed(ModelBuilder builder)
    {
      builder.Entity<GenreEntity>().HasData(new List<GenreEntity>
      {
        new GenreEntity() { Id = 1, Name = "Drama" },
        new GenreEntity() { Id = 2, Name = "Thriller" }
      });

      builder.Entity<MovieEntity>().HasData(new List<MovieEntity>
      {
        new MovieEntity() { Id = 1, Title = "The American", GenreId = 1 },
        new MovieEntity() { Id = 2, Title = "The Founder", GenreId = 1 },
        new MovieEntity() { Id = 3, Title = "In The Shadow of The Moon", GenreId = 2}
      });
    }
  }
}
