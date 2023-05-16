using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Data;
using MusicAPIV1.DTO;
using MusicAPIV1.Models;

namespace MusicAPIV1.Services
{
    public class GroupService : IGroupService
    {
        private readonly MusicDBContext ctx;
        public GroupService(MusicDBContext _ctx)
        {
            this.ctx = _ctx;
        }
        public async Task<List<Group>?> AddGroup(Group group)
        {
            await this.ctx.groups.AddAsync(group);
            await this.ctx.SaveChangesAsync();
            return await this.ctx.groups.ToListAsync(); ;
        }

        public async Task<List<Group>?> DeleteGroup(int id)
        {
            var group = await this.ctx.groups.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (group == null)
                return null;
            this.ctx.groups.Remove(group);
            await this.ctx.SaveChangesAsync();
            return await this.ctx.groups.ToListAsync(); ;
        }

        public async Task<List<Group>?> GetAllGroups()
        {
            var result = await this.ctx.groups.ToListAsync();
            return result;
        }

        public async Task<Group?> GetGroupByID(int id)
        {
            var group = await this.ctx.groups.Include(s => s.Songs).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (group == null)
                return null;
            return group;
        }

        public async Task<List<Group>?> GetGroupsByGenre(int genreID)
        {
            var group = await this.ctx.groups.Where(x => x.GroupGenreID == genreID).ToListAsync();
            if (group == null) return null;
            return group;
        }



        public async Task<List<Group>?> UpdateGroup(int id, Group group)
        {
            var _group = await this.ctx.groups.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_group == null)
                return null;
            _group.GroupName = group.GroupName;
            _group.GroupGenreID = group.GroupGenreID;
            _group.Description = group.Description;
            await this.ctx.SaveChangesAsync();
            return await this.ctx.groups.ToListAsync();
        }
    }
}
