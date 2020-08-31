using System.Collections.Generic;
using System.Threading.Tasks;
using Astroflix.ClientApi.Models;
using Astroflix.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Astroflix.ClientApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MovieController : ControllerBase
  {
    private readonly AstroflixContext _db;

    public MovieController(AstroflixContext context)
    {
      _db = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
      return await Task.Run(() => Ok(Movie.LoadMovies(_db)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAction(string id)
    {
      return await Task.Run(() => Ok(new Movie()));
    }
  }
}
