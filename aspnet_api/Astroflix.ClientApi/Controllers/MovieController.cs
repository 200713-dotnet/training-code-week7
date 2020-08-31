using System.Collections.Generic;
using System.Threading.Tasks;
using Astroflix.ClientApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Astroflix.ClientApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MovieController : ControllerBase
  {
    private List<Movie> movies = new List<Movie>()
    {
      new Movie() { Title = "The Founder", Genre = "Drama" },
      new Movie() { Title = "The American", Genre = "Drama" },
      new Movie() { Title = "In The Shawdow of The Moon", Genre = "Thriller" }
    };

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
      return await Task.Run(() => Ok(movies));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAction(string id)
    {
      return await Task.Run(() => Ok(new Movie()));
    }
  }
}
