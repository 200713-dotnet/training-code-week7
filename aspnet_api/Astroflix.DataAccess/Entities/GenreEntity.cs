using System.Collections.Generic;

namespace Astroflix.DataAccess.Entities
{
  public class GenreEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MovieEntity> Movies { get; set; }
  }
}
