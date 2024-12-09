using filmapp.Models;
using filmapp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace filmapp.Services
{
    public class FilmService
    {
        private readonly FilmContext _context;

        public FilmService(FilmContext context)
        {
            _context = context;
        }

        public async Task<List<Film>> GetAllAsync() => await _context.Films.ToListAsync();

        public async Task<Film?> GetAsync(int id) => await _context.Films.FindAsync(id);

        public async Task AddAsync(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var film = await GetAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }
        }
    }
}
