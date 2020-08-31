namespace Astroflix.DataAccess.Entities
{
  public class MovieEntity
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public int GenreId { get; set; }
    public GenreEntity Genre { get; set; }
  }
}
