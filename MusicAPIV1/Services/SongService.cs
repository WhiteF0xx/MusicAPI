using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Data;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;

namespace MusicAPIV1.Services
{
    public class SongService : ISongService
    {

        private readonly MusicDBContext ctx;
        public SongService(MusicDBContext _ctx)
        {
            this.ctx = _ctx;
        }
        public async Task<List<Song>?> AddSong(Song _song)
        {
            this.ctx.songs.Add(_song);
            await this.ctx.SaveChangesAsync();
            return await this.GetSongsByGroupID(_song.GroupId);
        }

        public async Task<List<Song>?> DeleteSong(int id)
        {
            var song = await this.ctx.songs.FirstOrDefaultAsync(s => s.Id == id);
            if (song is null)
                return null;
            this.ctx.songs.Remove(song);
            await this.ctx.SaveChangesAsync();
            return await this.GetSongsByGroupID(song.GroupId);
        }

        public async Task<List<Song>?> GetAllSongs()
        {
            return await this.ctx.songs.ToListAsync();
        }

        public async Task<List<Song>?> GetSongsByGroupID(int id)
        {
            var songs = await this.ctx.songs.Where(s => s.GroupId == id).ToListAsync();
            if (songs.Count == 0)
                return null;
            return songs;
        }

        public async Task<Song?> GetSongByID(int id)
        {
            var song = await this.ctx.songs.FirstOrDefaultAsync(s => s.Id == id);
            if (song is null)
                return null;
            return song;
        }

        public async Task<List<Song>?> UpdateSong(int id, Song _song)
        {
            var song = await this.GetSongByID(id);
            if (song is null)
                return null;
            song.SongName = _song.SongName;
            song.songURL = _song.songURL;
            song.GroupId = _song.GroupId;
            await this.ctx.SaveChangesAsync();
            return await this.GetSongsByGroupID(song.GroupId);
        }
    }

    }
