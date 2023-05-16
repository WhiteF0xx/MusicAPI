using Microsoft.EntityFrameworkCore;
using MusicAPIV2.Contracts;
using MusicAPIV2.Data;

namespace MusicAPIV2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MusicDBContext ctx;

        public GenericRepository(MusicDBContext _ctx) {
            this.ctx = _ctx;
        }

        public async Task<List<T>?> CreateAsync(T entity)
        {
            await this.ctx.AddAsync(entity);
            await this.ctx.SaveChangesAsync();
            return await this.GetAllAsync();
        }

        public async Task<List<T>?> DeleteAsync(int? id)
        {
            var entity = await this.GetByIDAsync(id);
            if (entity == null) { return null; }
            this.ctx.Set<T>().Remove(entity);
            await this.ctx.SaveChangesAsync();
            return await this.GetAllAsync();
        }

        public async Task<bool> Exists(int? id)
        {
            var entity = await this.GetByIDAsync(id);
            if (entity == null) { return false; }
            return true;
        }

        public async Task<List<T>?> GetAllAsync()
        {
            return await this.ctx.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIDAsync(int? id)
        {
            if (id is null) { return null; }
            return await this.ctx.Set<T>().FindAsync(id);
        }

        public async Task<List<T>?> UpdateAsync(T entity)
        {
            this.ctx.Update(entity);
            await this.ctx.SaveChangesAsync();
            return await this.GetAllAsync();
        }
    }
}
