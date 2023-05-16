using Microsoft.EntityFrameworkCore;
using MusicAPIV2.Contracts;
using MusicAPIV2.Data;
using MusicAPIV2.Models;

namespace MusicAPIV2.Repositories
{
    public class GroupRepository : GenericRepository<Group> ,IGroupRepository
    {
        public GroupRepository(MusicDBContext _ctx) : base(_ctx) { }

        public async Task<List<Group>?> GetGroupByGenre(int? genreID)
        {
            var group = await this.ctx.Set<Group>().Where(g => g.GroupGenreID == genreID).ToListAsync();
            if (group == null) { return null; }
            return group;
        }

        public async Task<Group?> GetGroupByIDWithSongs(int? groupID)
        {
            var group = await this.ctx.Set<Group>().Include(s => s.Songs).Where(i => i.Id == groupID).FirstOrDefaultAsync();
            if (group == null) { return null; }
            return group;
        }
    }
}
