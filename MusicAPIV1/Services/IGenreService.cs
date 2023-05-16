using MusicAPIV1.DTO;
using MusicAPIV1.Models;

namespace MusicAPIV1.Services
{
    public interface IGenreService
    {
        Task<List<Genre>?> GetAllGenre();
        Task<Genre?> GetGenreById(int id);
        Task<List<Genre>?> AddGenre(Genre genre);
        Task<List<Genre>?> UpdateGenre(int id, Genre genre);
        Task<List<Genre>?> DeleteGenre(int id);

    }
}
