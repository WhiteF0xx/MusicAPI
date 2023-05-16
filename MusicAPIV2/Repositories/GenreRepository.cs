using MusicAPIV2.Contracts;
using MusicAPIV2.Data;
using MusicAPIV2.Models;

namespace MusicAPIV2.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicDBContext _ctx) :base(_ctx)
        { }
    }
}
