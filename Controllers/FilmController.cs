using filmapp.Models;
using filmapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace filmapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _filmService;

        public FilmController(FilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _filmService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmService.GetAsync(id);
            return film == null ? NotFound() : Ok(film);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            await _filmService.AddAsync(film);
            return CreatedAtAction(nameof(Get), new { id = film.Id }, film);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Film film)
        {
            if (id != film.Id) return BadRequest();

            await _filmService.UpdateAsync(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filmService.DeleteAsync(id);
            return NoContent();
        }
    }
}
