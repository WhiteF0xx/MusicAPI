using MusicAPIV2.Contracts;
using MusicAPIV2.Models;

namespace MusicAPIV2.Repositories
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<List<Song>?> GetSongsByGroupID(int id);
        Task<List<Song>?> DeleteSongAsync(int? id);
        Task<List<Song>?> UpdateSongAsync(Song _song);
    }
}
