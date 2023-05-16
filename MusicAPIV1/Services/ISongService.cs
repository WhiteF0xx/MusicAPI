using MusicAPIV1.DTO;
using MusicAPIV1.Models;

namespace MusicAPIV1.Services
{
    public interface ISongService
    {

        Task<List<Song>?> GetAllSongs();
        Task<List<Song>?> GetSongsByGroupID(int id);
        Task<Song?> GetSongByID(int id);
        Task<List<Song>?> AddSong(Song song);
        Task<List<Song>?> UpdateSong(int id, Song song);
        Task<List<Song>?> DeleteSong(int id);

    }
}
