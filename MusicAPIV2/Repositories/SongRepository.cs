using Microsoft.EntityFrameworkCore;
using MusicAPIV2.Contracts;
using MusicAPIV2.Data;
using MusicAPIV2.Models;

namespace MusicAPIV2.Repositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(MusicDBContext _ctx) : base(_ctx) { }

        public async Task<List<Song>?> GetSongsByGroupID(int id)
        {
            var result = await this.ctx.songs.Where(x => x.GroupId == id).ToListAsync();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<Song>?> DeleteSongAsync(int? id)
        {
            var entity = await this.GetByIDAsync(id);
            if (entity is null)
            {
                return null;
            }
            this.ctx.Set<Song>().Remove(entity);
            await this.ctx.SaveChangesAsync();
            return await this.GetSongsByGroupID(entity.GroupId);
        }

        public async Task<List<Song>?> UpdateSongAsync(Song _song)
        {
            this.ctx.Update(_song);
            await this.ctx.SaveChangesAsync();
            return await this.GetSongsByGroupID(_song.GroupId);
        }
    }
}
