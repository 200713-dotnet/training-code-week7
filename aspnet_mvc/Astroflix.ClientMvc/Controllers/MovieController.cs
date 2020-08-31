using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Astroflix.ClientMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Astroflix.ClientMvc.Controllers
{
  public class MovieController : Controller
  {
    private readonly HttpClient _http;

    public MovieController(IConfiguration configuration)
    {
      _http = new HttpClient() { BaseAddress = new Uri(configuration["ServiceUrls:api"]) };
    }

    [HttpGet]
    public async Task<IActionResult> Home()
    {
      return View(await CallServiceAsync<List<MovieViewModel>>("/api/movie"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Detail(string id)
    {
      return View(await CallServiceAsync<MovieViewModel>($"/api/movie/{id}"));
    }

    private async Task<T> CallServiceAsync<T>(string url) where T : class
    {
      var response = await _http.GetAsync(url);

      return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
    }
  }
}
