using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Data;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;

namespace MusicAPIV1.Services
{
    public class GenreService : IGenreService
    {
        private readonly MusicDBContext ctx;
        public GenreService(MusicDBContext _ctx)
        {
            this.ctx = _ctx;
        }

        public async Task<List<Genre>?> AddGenre(Genre genre)
        {
            await this.ctx.genres.AddAsync(genre);
            await this.ctx.SaveChangesAsync();
            return await this.GetAllGenre();
        }


        public async Task<List<Genre>?> DeleteGenre(int id)
        {
            var _genre = await this.GetGenreById(id);
            if (_genre == null)
                return null;
            this.ctx.genres.Remove(_genre);
            await this.ctx.SaveChangesAsync();
            return await this.GetAllGenre();
        }

        public async Task<List<Genre>?> GetAllGenre()
        {
            return await this.ctx.genres.ToListAsync();
        }

        public async Task<Genre?> GetGenreById(int id)
        {
            var genre = await this.ctx.genres.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (genre == null)
                return null;
            return genre;
        }

        public async Task<List<Genre>?> UpdateGenre(int id, Genre genre)
        {
            var _genre = await this.GetGenreById(id);
            if (_genre == null)
                return null;
            _genre.GenreName = genre.GenreName;
            await this.ctx.SaveChangesAsync();
            return await this.GetAllGenre();
        }
    }
}
