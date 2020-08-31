using System.Collections.Generic;
using System.Linq;
using Astroflix.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Astroflix.ClientApi.Models
{
  public class Movie
  {
    public string Title { get; set; }
    public string Genre { get; set; }

    public static IEnumerable<Movie> LoadMovies(AstroflixContext context)
    {
      var movies = new List<Movie>();

      foreach(var movie in context.Movies.Include(e => e.Genre).ToList())
      {
        movies.Add(new Movie() { Title = movie.Title, Genre = movie.Genre.Name });
      }

      return movies;
    }
  }
}
